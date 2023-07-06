
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

        //bgmVolumeSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });

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
        audioManager.bgmSource.volume = bgmVolumeSlider.value;
        audioManager.sfxSource.volume = sfxVolumeSlider.value;
    }
}
