
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    private static readonly string BGMVolumePref = "BGMVolume";
    private static readonly string SFXVolumePref = "SFXVolume";
    private static readonly string FirstPlay = "FirstPlay";

    private int firsPlay;
    public float bgmVolume, sfxVolume;

    SliderSetup sliderSetup;


    public void UpdatePref(Slider bgmSlider, Slider sfxSlider)
    {
        PlayerPrefs.SetFloat(BGMVolumePref, bgmSlider.value);
        PlayerPrefs.SetFloat(SFXVolumePref, sfxSlider.value);
        PlayerPrefs.Save();
    }

    public void GetPref()
    {
        bgmVolume = PlayerPrefs.GetFloat(BGMVolumePref);
        sfxVolume = PlayerPrefs.GetFloat(SFXVolumePref);
    }

    private void Start()
    {
        sliderSetup = FindAnyObjectByType<SliderSetup>();

        firsPlay = PlayerPrefs.GetInt(FirstPlay);

        if (firsPlay == 0)
        {
            bgmVolume = .50f;
            sfxVolume = .50f;

            PlayerPrefs.SetFloat(BGMVolumePref, bgmVolume);
            PlayerPrefs.SetFloat(SFXVolumePref, sfxVolume);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            GetVolumePref();
        }
    }


    public void GetVolumePref()
    {
        bgmVolume = PlayerPrefs.GetFloat(BGMVolumePref);
        sfxVolume = PlayerPrefs.GetFloat(SFXVolumePref);
    }


    public void SaveVolumeSettings() {
        PlayerPrefs.SetFloat(BGMVolumePref, sliderSetup.bgmVolumeSlider.value);
        PlayerPrefs.SetFloat(SFXVolumePref, sliderSetup.sfxVolumeSlider.value);
    }

    void OnApplicationFocus(bool focus)
    {
        if (!focus) 
            SaveVolumeSettings();
    }

    public void GetSourceAndUpdate(Slider slider, Audio[] audio)
    {
        for (int i = 0; i < audio.Length; i++)
        {
            audio[i].audioSource.volume = slider.value;
        }
    }
}
