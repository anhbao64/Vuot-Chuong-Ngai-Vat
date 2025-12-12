using UnityEngine;

public static class GameData
{
    public static int currentCoin = 0;
    public static float currentTime = 0f;

    // Lấy dữ liệu đã lưu từ PlayerPrefs
    public static void LoadData()
    {
        currentCoin = PlayerPrefs.GetInt("TotalCoin", 0);
        currentTime = PlayerPrefs.GetFloat("TotalTime", 0f);
    }

    // Lưu lại vào PlayerPrefs khi cần
    public static void SaveData()
    {
        PlayerPrefs.SetInt("TotalCoin", currentCoin);
        PlayerPrefs.SetFloat("TotalTime", currentTime);
        PlayerPrefs.Save();
    }

    // Best record
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
