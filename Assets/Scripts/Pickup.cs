using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item; // Имя или тип предмета

    public float height = 1.5f;
    public float duration = 1f;
    
    private Vector3 posA, posB;
    private float timer = 0f;
    private bool toB = true;
    
    void Start()
    {
        posA = transform.position;
        posB = posA + Vector3.up * height;
    }
    
    void Update()
    {
        timer += Time.deltaTime / duration;
        
        if (toB)
            transform.position = Vector3.Lerp(posA, posB, timer);
        else
            transform.position = Vector3.Lerp(posB, posA, timer);
        
        if (timer >= 1f)
        {
            timer = 0f;
            toB = !toB;
        }
    }
}