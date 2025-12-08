using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float patrolDistance = 3f; // khoảng cách đi từ spawn

    private Vector2 startPos;
    private bool movingRight = true;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position; // lưu vị trí spawn
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
            sr.flipX = false; // lật sprite sang phải
            if (transform.position.x >= startPos.x + patrolDistance)
                movingRight = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            sr.flipX = true; // lật sprite sang trái
            if (transform.position.x <= startPos.x - patrolDistance)
                movingRight = true;
        }
    }
}
