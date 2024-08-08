using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public int Score { get; private set; }
    public int Lives { get; private set; } = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Score = 0;
    }

    public const string SceneMainMenu = "Main-Menu";
    public const string SceneOptions = "Options";
    public const string SceneLoading = "LoadingScene";
    public const string SceneInfo = "Info";

    public void AddScore(int value)
    {
        Score += value;
    }

    public void LoseLife()
    {
        Lives--;

        if (Lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        AudioManager.instance.PlayGameOverMusic();
        SceneManager.LoadScene("GameOver");
    }

    public void ResetGame()
    {
        Score = 0;
        Lives = 3;
        PlayerPrefs.SetString("NextSceneName", "Level1");
    }
}
