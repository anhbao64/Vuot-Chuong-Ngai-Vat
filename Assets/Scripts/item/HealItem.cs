using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int healAmount = 1; // hồi 1 máu

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();

            if (health != null)
            {
                bool healed = health.Heal(healAmount);

                if (healed)
                {
                    // ✔ Player chưa full máu → heal thành công → item biến mất
                    Destroy(gameObject);
                }
                else
                {
                    // ❌ Player full máu → KHÔNG nhặt item
                    // (không làm gì cả)
                }
            }
        }
    }
}
