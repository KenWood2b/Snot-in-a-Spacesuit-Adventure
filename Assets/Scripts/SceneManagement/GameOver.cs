using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main-Menu-Example");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
