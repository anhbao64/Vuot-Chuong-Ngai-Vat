using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Gọi End Game
            if (GameManager.Instance != null)
            {
                GameManager.Instance.ShowEndGame();
            }
            else
            {
                Debug.LogError("Không tìm thấy GameManager Instance!");
            }

            Destroy(gameObject); // Xóa key
        }
    }
}
