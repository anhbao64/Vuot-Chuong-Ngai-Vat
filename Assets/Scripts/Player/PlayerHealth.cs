using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthBar.UpdateUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Hồi máu. Trả về TRUE nếu hồi thành công.
    /// Trả về FALSE nếu không hồi (full máu).
    /// </summary>
    public bool Heal(int amount)
    {
        if (isDead) return false;

        if (currentHealth >= maxHealth)
        {
            // ❌ Full máu → không heal
            return false;
        }

        // ✔ Heal thành công
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthBar.UpdateUI();
        return true;
    }

    // =============================
    //        ĐÃ CHỈNH TẠI ĐÂY
    // =============================
    public void Die()     // <--- đổi thành public
    {
        if (isDead) return;

        isDead = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ShowGameOver();
        }
        else
        {
            Debug.LogError("Không tìm thấy GameManager Instance!");
        }

        Debug.Log("Player chết – bật GameOver");
    }
}
