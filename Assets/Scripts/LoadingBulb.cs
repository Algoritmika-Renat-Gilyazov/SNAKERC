using UnityEngine;

namespace UI
{
    public class LoadingBulb : MonoBehaviour
    {
        public void Update()
        {
            transform.Rotate(0, 0, -200 * Time.deltaTime);
        }
    }
}