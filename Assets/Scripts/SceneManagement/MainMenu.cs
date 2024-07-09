using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        
        PlayerPrefs.SetString("NextSceneName", "Level1");

        
        SceneManager.LoadScene("LoadingScene");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options-Example");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu-Example");
    }
}

