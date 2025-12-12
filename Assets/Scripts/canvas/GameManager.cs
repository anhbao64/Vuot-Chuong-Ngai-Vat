using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public GameObject gameOverUI;
    public GameObject endGameUI;

    private float playTime = 0f; // thời gian trong màn

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Time.timeScale = 1f;

        // Load data coin/time đã lưu
        GameData.LoadData();
    }

    private void Update()
    {
        playTime += Time.deltaTime; // tính thời gian chơi để so kỷ lục
    }

    // ============= DEAD =============
    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // ============= WIN =============
    public void ShowEndGame()
    {
        endGameUI.SetActive(true);
        Time.timeScale = 0f;

        // Cộng thời gian và coin hiện tại
        GameData.currentTime += playTime;
        GameData.SaveData();

        // Lưu kỷ lục nếu tốt hơn
        GameData.SaveBestRecord(playTime);

        Debug.Log("Win! Time: " + playTime + " | Best: " + GameData.GetBestRecord());
    }

    // ============= RESTART =============
    public void RestartGame()
    {
        // Trước khi restart thì lưu coin/time
        GameData.SaveData();

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
