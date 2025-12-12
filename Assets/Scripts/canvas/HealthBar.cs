using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth player;
    public Image fillImage;
    public float smoothSpeed = 3f;

    private float targetFill;

    public void UpdateUI()
    {
        if (player == null) return;

        float hpPercent = (float)player.currentHealth / player.maxHealth;
        targetFill = hpPercent;
    }

    void Update()
    {
        fillImage.fillAmount =
            Mathf.Lerp(fillImage.fillAmount, targetFill, smoothSpeed * Time.deltaTime);
    }
}
