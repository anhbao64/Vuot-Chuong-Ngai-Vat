using UnityEngine;

public class PlayerSpeedBuff : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float jumpMultiplier = 1.5f;
    public float buffDuration = 10f;

    public SpeedBar speedBar;
    public PlayerController playerController;

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
        // ⏱ Reset thời gian MỖI LẦN ăn
        buffTimer = buffDuration;
        speedBar.StartTimer(buffDuration);

        // 🔊 SOUND → kêu MỖI LẦN
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPowerUp();
        }

        // ⚡ Chỉ tăng chỉ số 1 lần
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
