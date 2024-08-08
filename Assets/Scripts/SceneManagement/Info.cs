using UnityEngine;
using UnityEngine.SceneManagement;
public class Info : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main-Menu");
    }
}
