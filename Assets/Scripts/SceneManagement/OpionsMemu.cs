using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.LoadSettings();
            musicVolumeSlider.value = AudioManager.instance.musicSource.volume;
            sfxVolumeSlider.value = AudioManager.instance.sfxSource.volume;
        }

        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicVolume(volume);
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetSFXVolume(volume);
        }
    }

    public void BackToMainMenu()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SaveSettings();
        }
        SceneManager.LoadScene("Main-Menu");
    }
}

