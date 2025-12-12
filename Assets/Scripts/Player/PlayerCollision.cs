using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int damagePerHit = 1; // mỗi lần va chạm trừ 1 HP

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(damagePerHit);
        }
    }
}
