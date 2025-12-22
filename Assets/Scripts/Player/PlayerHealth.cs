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

    public bool Heal(int amount)
    {
        if (isDead) return false;

        if (currentHealth >= maxHealth)
            return false;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.UpdateUI();

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPowerUp();
        }

        return true;
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayExplosion();
        }

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
