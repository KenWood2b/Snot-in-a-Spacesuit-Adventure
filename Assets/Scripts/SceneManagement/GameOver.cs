using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(GameMaster.SceneLoading);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(GameMaster.SceneMainMenu);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
