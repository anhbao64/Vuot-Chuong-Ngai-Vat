using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int damagePerHit = 1;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayHurt();
            }

            playerHealth.TakeDamage(damagePerHit);
        }
    }
}
