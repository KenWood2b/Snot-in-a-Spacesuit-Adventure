using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingSceneController : MonoBehaviour
{
    public Text loadingText;
    public Slider progressBar;
    public Text levelInfoText; 

    void Start()
    {
        
        string nextSceneName = PlayerPrefs.GetString("NextSceneName");
        SetLevelInfo(nextSceneName);
        AudioManager.instance.PlayLoadingMusic();
        StartCoroutine(LoadAsynchronously(nextSceneName));
    }

    void SetLevelInfo(string sceneName)
    {
        switch (sceneName)
        {
            case "Level1":
                levelInfoText.text = "Level 1";
                break;
            case "Level2":
                levelInfoText.text = "Level 2";
                break;

            default:
                levelInfoText.text = "Загрузка...";
                break;
        }
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        
        while (!operation.isDone)
        {
            
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;
            loadingText.text = "Загрузка: " + (progress * 100f).ToString("F0") + "%";



            if (operation.progress >= 0.9f)
            {
                progressBar.value = 1f;
                loadingText.text = "Загрузка: 100%";
                yield return new WaitForSeconds(1);

                operation.allowSceneActivation = true;
                AudioManager.instance.PlayGameMusic(sceneName);
            }

            yield return null;
        }
    }
}