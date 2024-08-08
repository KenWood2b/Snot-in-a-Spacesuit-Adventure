using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        GameMaster.instance.ResetGame();
        SceneManager.LoadScene(GameMaster.SceneLoading);
    }

    public void MainMenu()
    {
        GameMaster.instance.ResetGame();
        SceneManager.LoadScene(GameMaster.SceneMainMenu);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
