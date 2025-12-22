using UnityEngine;
using TMPro;

public class PlayerCoin : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinText;

    void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateUI();

        // 🔊 COIN SOUND
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayCoin();
        }
    }

    void UpdateUI()
    {
        coinText.text = $"Coin: {coinCount}";
    }
}
