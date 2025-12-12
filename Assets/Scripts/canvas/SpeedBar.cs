using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    public Image fillImage;

    private float duration;
    private float timer;
    private bool isActive = false;

    void Update()
    {
        if (!isActive) return;

        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, duration);

        fillImage.fillAmount = timer / duration;

        if (timer <= 0)
        {
            isActive = false;
            gameObject.SetActive(false);
        }
    }

    public void StartTimer(float time)
    {
        duration = time;
        timer = time;

        fillImage.fillAmount = 1f;

        gameObject.SetActive(true);
        isActive = true;
    }
}
