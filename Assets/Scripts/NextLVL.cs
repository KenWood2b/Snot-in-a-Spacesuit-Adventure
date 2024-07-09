using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour
{
    public string nextLevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadNextLevel();
           
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
