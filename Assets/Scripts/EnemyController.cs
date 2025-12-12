using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float patrolDistance = 3f;

    [Header("Attack Settings")]
    public int damageAmount = 1;        // Gây 1 damage
    public float damageInterval = 1f;   // 1 giây gây 1 damage
    private float damageTimer = 0f;

    private Vector2 startPos;
    private bool movingRight = true;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            sr.flipX = false;
            if (transform.position.x >= startPos.x + patrolDistance)
                movingRight = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            sr.flipX = true;
            if (transform.position.x <= startPos.x - patrolDistance)
                movingRight = true;
        }
    }

    // Enemy gây damage mỗi giây khi Player đứng trong vùng
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                // Lấy PlayerHealth trên Player
                PlayerHealth hp = collision.GetComponent<PlayerHealth>();
                if (hp != null)
                {
                    hp.TakeDamage(damageAmount);
                }

                damageTimer = 0f;  // reset để tính lại 1 giây tiếp theo
            }
        }
    }

    // Reset timer khi Player rời khỏi enemy
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damageTimer = 0f;
        }
    }
}
