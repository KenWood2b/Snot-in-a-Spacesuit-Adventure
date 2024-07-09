using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip mainMenuMusic;
    public AudioClip optionsMusic;
    public AudioClip loadingMusic;
    public AudioClip gameOverMusic;
    public AudioClip gameMusicLVL1;
    public AudioClip gameMusicLVL2;
    public AudioClip coinSFX;
    public AudioClip jumpSFX;
    public AudioClip finalSFX;
    public AudioClip checkPointSFX;
    public AudioClip keyPickupSFX;
    public AudioClip doorOpenSFX;
    public AudioClip enemyKillSFX;
    public AudioClip jumpPadSFX;
    public AudioClip lifeLostSFX;

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

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMainMenuMusic();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main-Menu-Example" || scene.name == "Options-Example")
        {
            PlayMainMenuMusic();
        }
        else if (scene.name == "LoadingScene")
        {
            PlayLoadingMusic();
        }
        else if (scene.name == "GameOver-Example")
        {
            PlayGameOverMusic();
        }
        else
        {
            PlayGameMusic(scene.name);
        }
    }

    public void PlayMainMenuMusic()
    {
        PlayMusic(mainMenuMusic);
    }

    public void PlayLoadingMusic()
    {
        PlayMusic(loadingMusic);
    }
    public void PlayGameOverMusic()
    {
        PlayMusic(gameOverMusic);
    }

    public void PlayGameMusic(string levelName)
    {
        switch (levelName)
        {
            case "LVL 1":
                PlayMusic(gameMusicLVL1);
                break;
            case "LVL 2":
                PlayMusic(gameMusicLVL2);
                break;

            default:
                PlayMusic(gameMusicLVL1);
                break;
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip)
            return;

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayCoinSFX()
    {
        PlaySFX(coinSFX);
    }

    public void PlayJumpSFX()
    {
        PlaySFX(jumpSFX);
    }

    public void PlayFinalSFX()
    {
        PlaySFX(finalSFX);
    }
    public void PlayCheckPointSFX()
    {
        PlaySFX(checkPointSFX);
    }

    public void PlayKeyPickupSFX()
    {
        PlaySFX(keyPickupSFX);
    }

    public void PlayDoorOpenSFX()
    {
        PlaySFX(doorOpenSFX);
    }

    public void PlayEnemyKillSFX()
    {
        PlaySFX(enemyKillSFX);
    }

    public void PlayJumpPadSFX()
    {
        PlaySFX(jumpPadSFX);
    }

    public void PlayLifeLostSFX()
    {
        PlaySFX(lifeLostSFX);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume");
        }
    }
}