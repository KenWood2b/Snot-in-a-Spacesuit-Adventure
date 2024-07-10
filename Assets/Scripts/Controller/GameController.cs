using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;
    public Image[] livesImage;
    public Sprite[] lifeSprites;

   /* private int score;
    private int lives = 3;*/

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
        //score = 0;
        UpdateScoreText();
        UpdateLivesImage();
    }

    public void AddScore(int value)
    {
        //score += value;
        GameMaster.instance.AddScore(value);
        UpdateScoreText();
        //SaveGameData();
    }

    public void LoseLife()
    {
        //lives--;
        GameMaster.instance.LoseLife();
        UpdateLivesImage();

        /*if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            SaveGameData();
        }*/
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            //scoreText.text = "Score: " + score.ToString();
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

    /*public int GetLives()
    {
        return lives;
    }*/

    /*public void GameOver()
    {
        AudioManager.instance.PlayGameOverMusic();
        SceneManager.LoadScene("GameOver");
    }*/

    /*public void SaveGameData()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.Save();
    }

    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        if (PlayerPrefs.HasKey("Lives"))
        {
            lives = PlayerPrefs.GetInt("Lives");
        }
    }*/

}