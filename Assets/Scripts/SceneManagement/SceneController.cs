using UnityEngine;

public enum NameScene
{
    MainMenu,
    Loading,
    GameOver
}
public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject _sceneMainMenu;
    [SerializeField] GameObject _sceneLoading;
    [SerializeField] GameObject _sceneGameOver;

    public static SceneController instance;
   
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
        
    }

    public void ShowScene(NameScene scene)
    {
        switch (scene)
        {
            case NameScene.MainMenu:
                _sceneMainMenu.SetActive(true);
                _sceneLoading.SetActive(false);
                _sceneGameOver.SetActive(false);
                break;
            case NameScene.Loading:
                _sceneMainMenu.SetActive(false);
                _sceneLoading.SetActive(true);
                _sceneGameOver.SetActive(false);
                break;
            case NameScene.GameOver:
                _sceneMainMenu.SetActive(false);
                _sceneLoading.SetActive(false);
                _sceneGameOver.SetActive(true);
                break;
        }
    }
}