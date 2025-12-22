using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string sceneName; // MapLV1, MapLV2...

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
