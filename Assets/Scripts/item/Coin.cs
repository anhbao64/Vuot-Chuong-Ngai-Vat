using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1; // giá trị coin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCoin playerCoin = collision.GetComponent<PlayerCoin>();

            if (playerCoin != null)
            {
                playerCoin.AddCoin(value);
            }

            Destroy(gameObject); // coin biến mất
        }
    }
}
