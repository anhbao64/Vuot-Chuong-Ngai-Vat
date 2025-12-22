using UnityEngine;

public static class GameData
{
    // Dữ liệu gameplay
    public static int currentCoin = 0;
    public static float currentTime = 0f;

    // Lưu tên scene trước khi load menu (để quay lại)
    public static string lastScene = "MenuMapScene";

    // ================== LOAD DATA ==================
    public static void LoadData()
    {
        currentCoin = PlayerPrefs.GetInt("TotalCoin", 0);
        currentTime = PlayerPrefs.GetFloat("TotalTime", 0f);
        lastScene = PlayerPrefs.GetString("LastScene", "MenuMapScene");
    }

    // ================== SAVE DATA ==================
    public static void SaveData()
    {
        PlayerPrefs.SetInt("TotalCoin", currentCoin);
        PlayerPrefs.SetFloat("TotalTime", currentTime);
        PlayerPrefs.SetString("LastScene", lastScene);
        PlayerPrefs.Save();
    }

    // ================== BEST RECORD ==================
    public static void SaveBestRecord(float record)
    {
        float best = PlayerPrefs.GetFloat("BestRecord", float.MaxValue);

        if (record < best)
        {
            PlayerPrefs.SetFloat("BestRecord", record);
            PlayerPrefs.Save();
        }
    }

    public static float GetBestRecord()
    {
        return PlayerPrefs.GetFloat("BestRecord", float.MaxValue);
    }
}
