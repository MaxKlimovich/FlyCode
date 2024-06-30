using UnityEngine;

namespace Script
{
    public class Heart : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bird"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}