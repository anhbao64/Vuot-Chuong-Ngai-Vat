using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI - End States")]
    public GameObject gameOverUI;
    public GameObject endGameUI;

    [Header("Pause Buttons")]
    public Button stopButton;
    public Button resumeButton;
    public Button replayButton;

    [Header("Other UI to Hide")]
    public GameObject playerHealthUI;
    public GameObject speedBaz;

    private float playTime = 0f;
    private bool isPaused = false;
    private bool isGameEnded = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Time.timeScale = 1f;
        GameData.LoadData();
    }

    private void Start()
    {
        SetRunningState();
    }

    private void Update()
    {
        if (!isPaused && !isGameEnded)
            playTime += Time.deltaTime;
    }

    // ===== STOP / PAUSE =====
    public void StopGame()
    {
        if (isGameEnded || isPaused) return;

        PlayButtonSound();

        isPaused = true;
        Time.timeScale = 0f;
        SetPausedState();
    }

    public void ResumeGame()
    {
        if (isGameEnded || !isPaused) return;

        PlayButtonSound();

        isPaused = false;
        Time.timeScale = 1f;
        SetRunningState();
    }

    // ===== OPEN MENU (quay lại MenuMapScene) =====
    public void OpenMenu()
    {
        PlayButtonSound();

        // lưu dữ liệu gameplay trước khi rời scene
        GameData.currentTime += playTime;
        GameData.lastScene = SceneManager.GetActiveScene().name;
        GameData.SaveData();

        // load lại MenuMapScene
        SceneManager.LoadScene("MenuGame");
    }

    // ===== UI STATES =====
    private void SetRunningState()
    {
        if (stopButton != null) stopButton.gameObject.SetActive(true);
        if (resumeButton != null) resumeButton.gameObject.SetActive(false);
    }

    private void SetPausedState()
    {
        if (stopButton != null) stopButton.gameObject.SetActive(false);
        if (resumeButton != null) resumeButton.gameObject.SetActive(true);
    }

    private void HideGameplayUI()
    {
        if (stopButton != null) stopButton.gameObject.SetActive(false);
        if (resumeButton != null) resumeButton.gameObject.SetActive(false);
        if (replayButton != null) replayButton.gameObject.SetActive(false);

        if (playerHealthUI != null) playerHealthUI.SetActive(false);
        if (speedBaz != null) speedBaz.SetActive(false);
    }

    // ===== GAME OVER =====
    public void ShowGameOver()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        Time.timeScale = 0f;

        gameOverUI.SetActive(true);
        HideGameplayUI();
    }

    // ===== WIN =====
    public void ShowEndGame()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        Time.timeScale = 0f;

        endGameUI.SetActive(true);

        GameData.currentTime += playTime;
        GameData.SaveData();

        HideGameplayUI();

        Debug.Log("Win! Time: " + playTime);
    }

    // ===== RESTART =====
    public void RestartGame()
    {
        PlayButtonSound();

        GameData.SaveData();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ===== UI SOUND =====
    private void PlayButtonSound()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayButtonClick();
    }
}
