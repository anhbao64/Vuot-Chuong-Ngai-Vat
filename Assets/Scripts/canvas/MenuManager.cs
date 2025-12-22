using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject menuPlay;
    public GameObject menuMap;
    public GameObject menuSetting;

    [Header("Camera")]
    public GameObject cameraMenu;

    void Start()
    {
        ShowMainMenu();

        // 🔊 phát nhạc menu nếu chưa có
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayBackgroundMusic();
    }

    void HideAll()
    {
        mainMenu.SetActive(false);
        menuPlay.SetActive(false);
        menuMap.SetActive(false);
        menuSetting.SetActive(false);
    }

    void PlayTap()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayButtonClick();
    }

    // ===== MAIN MENU =====
    public void ShowMainMenu()
    {
        PlayTap();
        HideAll();
        mainMenu.SetActive(true);
        cameraMenu.SetActive(true);
    }

    public void ShowMenuPlay()
    {
        PlayTap();
        HideAll();
        menuPlay.SetActive(true);
        cameraMenu.SetActive(true);
    }

    public void ShowMenuSetting()
    {
        PlayTap();
        HideAll();
        menuSetting.SetActive(true);
        cameraMenu.SetActive(true);
    }

    // ===== MENU PLAY =====
    public void ShowMenuMap()
    {
        PlayTap();
        HideAll();
        menuMap.SetActive(true);
        cameraMenu.SetActive(true);
    }

    public void BackFromPlay()
    {
        PlayTap();
        ShowMainMenu();
    }

    // ===== MENU MAP =====
    public void LoadMapLV1()
    {
        PlayTap();

        // lưu tên scene menu hiện tại
        GameData.lastScene = SceneManager.GetActiveScene().name;

        // load scene gameplay
        SceneManager.LoadScene("MapLV1");
    }

    public void LoadMapLV2()
    {
        PlayTap();

        // lưu tên scene menu hiện tại
        GameData.lastScene = SceneManager.GetActiveScene().name;

        // load scene gameplay
        SceneManager.LoadScene("MapLV2");
    }

    public void BackFromMap()
    {
        PlayTap();

        // **không load scene nữa**, chỉ show menuPlay
        ShowMenuPlay();
    }

    // ===== MENU SETTING =====
    public void BackFromSetting()
    {
        PlayTap();
        ShowMainMenu();
    }

    // ===== QUIT =====
    public void QuitGame()
    {
        PlayTap();
        Application.Quit();
    }
}
