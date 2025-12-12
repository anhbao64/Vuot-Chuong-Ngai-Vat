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
    }

    void UpdateUI()
    {
        coinText.text = $"Coin: {coinCount}";
    }
}
