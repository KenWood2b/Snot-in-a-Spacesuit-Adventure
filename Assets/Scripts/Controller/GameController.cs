using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;
    public Image[] livesImage;
    public Sprite[] lifeSprites;

    private int score;
    private int lives = 3;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        UpdateScoreText();
        UpdateLivesImage();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesImage();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void UpdateLivesImage()
    {
        if (livesImage != null && lifeSprites.Length > 0)
        {
            int spriteIndex = Mathf.Clamp(lives - 1, 0, lifeSprites.Length - 1);
            for (int i = 0; i < livesImage.Length; i++)
            {
              if(i + 1 > lives)
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

    public int GetLives()
    {
        return lives;
    }

    public void GameOver()
    {
        AudioManager.instance.PlayGameOverMusic();
        SceneManager.LoadScene("GameOver-Example");
    }

}