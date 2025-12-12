using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth hp = collision.GetComponent<PlayerHealth>();

            if (hp != null)
            {
                hp.Die();   // Gọi chết ngay lập tức
            }
        }
    }
}
