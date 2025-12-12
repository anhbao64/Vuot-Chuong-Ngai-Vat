using UnityEngine;
using TMPro;

public class PlayTimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private float timer = 0f;
    private bool isCounting = true;

    void Update()
    {
        if (!isCounting) return;

        timer += Time.deltaTime;

        int displayTime = Mathf.FloorToInt(timer); // 0,1,2,3...

        timeText.text = $"Time: {displayTime}";
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    public void ResetTimer()
    {
        timer = 0f;
        isCounting = true;
    }
}
