
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    private static readonly string BGMVolumePref = "BGMVolume";
    private static readonly string SFXVolumePref = "SFXVolume";
    private static readonly string FirstPlay = "FirstPlay";

    private int firsPlay;
    private float bgmVolume, sfxVolume;

    public Slider bgmVolumeSlider, sfxVolumeSlider;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        firsPlay = PlayerPrefs.GetInt(FirstPlay);

        if (firsPlay == 0)
        {
            bgmVolume = .50f;
            sfxVolume = .50f;

            bgmVolumeSlider.value = bgmVolume;
            PlayerPrefs.SetFloat(BGMVolumePref, bgmVolume);

            sfxVolumeSlider.value = sfxVolume;
            PlayerPrefs.SetFloat(SFXVolumePref, sfxVolume);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            bgmVolume = PlayerPrefs.GetFloat(BGMVolumePref);
            bgmVolumeSlider.value = bgmVolume;

            sfxVolume = PlayerPrefs.GetFloat(SFXVolumePref);
            sfxVolumeSlider.value = sfxVolume;
        }
    }


    public void SaveVolumeSettings() {

        PlayerPrefs.SetFloat(BGMVolumePref, bgmVolumeSlider.value);
        PlayerPrefs.SetFloat(SFXVolumePref, sfxVolumeSlider.value);
    }

    void OnApplicationFocus(bool focus)
    {
        if (!focus) 
            SaveVolumeSettings();
    }


    public void UpdateVolume() 
    {
        GetSourceAndUpdate(bgmVolumeSlider, audioManager.audioBGM);
        GetSourceAndUpdate(sfxVolumeSlider, audioManager.audioSFX);

    }


    void GetSourceAndUpdate(Slider slider, Audio[] audio)
    {
        for (int i = 0; i < audio.Length; i++)
        {
            audio[i].audioSource.volume = slider.value;
        }
    }
}
