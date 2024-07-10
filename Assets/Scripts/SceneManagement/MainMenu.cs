using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        
        PlayerPrefs.SetString("NextSceneName", "Level1");

        
        SceneManager.LoadScene(GameMaster.SceneLoading);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(GameMaster.SceneOptions);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(GameMaster.SceneMainMenu);
    }
}

