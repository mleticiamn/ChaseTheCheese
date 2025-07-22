using UnityEngine;

public class DropBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject); // Destroi o pingo ao tocar o chão
        }
    }
}