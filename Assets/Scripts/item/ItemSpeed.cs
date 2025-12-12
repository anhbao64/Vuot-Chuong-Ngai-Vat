using UnityEngine;

public class ItemSpeed : MonoBehaviour
{
    public float duration = 10f;         // thời gian hiệu lực buff

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerSpeedBuff buff = collision.GetComponent<PlayerSpeedBuff>();

            if (buff != null)
            {
                buff.ActivateBuff();   // buff cùng loại → reset thời gian
            }

            Destroy(gameObject);        // item biến mất
        }
    }
}
