using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 7f;
    public float jumpDuration = 0.5f; // thời gian nhảy tối thiểu

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true; // giữ player thẳng
    }

    void Update()
    {
        CheckGround();
        HandleInput();
        UpdateAnimation();
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && rb.linearVelocity.y <= 0f)
        {
            isJumping = false; // reset nhảy khi chạm đất
        }
    }

    private void HandleInput()
    {
        float moveX = 0f;

        // Di chuyển ngang
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
            sr.flipX = false;
        }

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // Nhảy
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // reset tốc độ rơi
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            isJumping = true;
            jumpTimeCounter = jumpDuration; // bật timer nhảy
        }

        // Giữ trạng thái nhảy ít nhất jumpDuration
        if (isJumping)
        {
            jumpTimeCounter -= Time.deltaTime;
            if (jumpTimeCounter <= 0f)
            {
                isJumping = false;
            }
        }
    }

    private void UpdateAnimation()
    {
        // Chạy khi di chuyển trên mặt đất và không nhảy
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.01f && isGrounded && !isJumping;

        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", isJumping);
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
