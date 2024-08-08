using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;
    public Image[] livesImage;
    public Sprite[] lifeSprites;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        UpdateLivesImage();
    }

    public void AddScore(int value)
    {
        GameMaster.instance.AddScore(value);
        UpdateScoreText();
    }

    public void LoseLife()
    {
        GameMaster.instance.LoseLife();
        UpdateLivesImage();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameMaster.instance.Score.ToString();
        }
    }


    void UpdateLivesImage()
    {
        if (livesImage != null && lifeSprites.Length > 0)
        {
            int spriteIndex = Mathf.Clamp(GameMaster.instance.Lives - 1, 0, lifeSprites.Length - 1);
            for (int i = 0; i < livesImage.Length; i++)
            {
                if (i + 1 > GameMaster.instance.Lives)
                {
                    livesImage[i].gameObject.SetActive(false);
                }
                else
                {
                    livesImage[i].gameObject.SetActive(true);
                }

            }

        }
    }
}