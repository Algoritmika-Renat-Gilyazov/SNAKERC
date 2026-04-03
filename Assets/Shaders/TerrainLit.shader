Shader "SRP/Triplanar"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Tiling ("Texture Scale", Float) = 1.0
        _Sharpness ("Blend Sharpness", Range(1, 64)) = 10
    }
    SubShader
    {
        Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 worldPos   : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
            };

            sampler2D _MainTex;
            float _Tiling;
            float _Sharpness;

            Varyings vert (Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.worldPos = TransformObjectToWorld(input.positionOS.xyz);
                output.worldNormal = TransformObjectToWorldNormal(input.normalOS);
                return output;
            }

            half4 frag (Varyings input) : SV_Target
            {
                // Считаем веса для трех плоскостей проекции
                float3 blending = abs(input.worldNormal);
                blending /= (blending.x + blending.y + blending.z);
                blending = pow(blending, _Sharpness); // Делаем переходы на углах четче
                blending /= (blending.x + blending.y + blending.z);

                // Проекции с трех сторон (X, Y, Z)
                float2 uvX = input.worldPos.zy * _Tiling;
                float2 uvY = input.worldPos.xz * _Tiling;
                float2 uvZ = input.worldPos.xy * _Tiling;

                half4 colX = tex2D(_MainTex, uvX);
                half4 colY = tex2D(_MainTex, uvY);
                half4 colZ = tex2D(_MainTex, uvZ);

                // Смешиваем результат
                return colX * blending.x + colY * blending.y + colZ * blending.z;
            }
            ENDHLSL
        }
    }
}