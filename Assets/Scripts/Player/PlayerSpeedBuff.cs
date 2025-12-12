using UnityEngine;

public class PlayerSpeedBuff : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float jumpMultiplier = 1.5f;
    public float buffDuration = 10f;

    public SpeedBar speedBar; // gán SpeedBar từ Inspector
    public PlayerController playerController; // script di chuyển của bạn

    private float buffTimer = 0f;
    private bool isBuffActive = false;

    private float originalSpeed;
    private float originalJump;

    void Start()
    {
        originalSpeed = playerController.moveSpeed;
        originalJump = playerController.jumpForce;
    }

    void Update()
    {
        if (!isBuffActive) return;

        buffTimer -= Time.deltaTime;

        if (buffTimer <= 0)
        {
            EndBuff();
        }
    }

    public void ActivateBuff()
    {
        buffTimer = buffDuration;          // reset về full 10s
        speedBar.StartTimer(buffDuration); // reset UI

        if (!isBuffActive)
        {
            isBuffActive = true;

            playerController.moveSpeed = originalSpeed * speedMultiplier;
            playerController.jumpForce = originalJump * jumpMultiplier;
        }
    }

    private void EndBuff()
    {
        isBuffActive = false;

        playerController.moveSpeed = originalSpeed;
        playerController.jumpForce = originalJump;
    }
}
