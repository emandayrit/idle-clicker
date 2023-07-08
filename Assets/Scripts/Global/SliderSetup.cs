
using UnityEngine;
using UnityEngine.UI;

public class SliderSetup : MonoBehaviour
{
    public Slider bgmVolumeSlider, sfxVolumeSlider;

    VolumeController volumeController;
    AudioManager audioManager;


    private void Start()
    {
        volumeController = FindAnyObjectByType<VolumeController>();
        audioManager = FindAnyObjectByType<AudioManager>();

        UpdateSlider();
        UpdateVolume();

        bgmVolumeSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });

    }


    public void UpdateSlider()
    {
        volumeController.GetPref();
        bgmVolumeSlider.value = volumeController.bgmVolume;
        sfxVolumeSlider.value = volumeController.sfxVolume;
    }

    public void UpdateVolume()
    {
        volumeController.UpdatePref(bgmVolumeSlider, sfxVolumeSlider);

        volumeController.GetSourceAndUpdate(bgmVolumeSlider, audioManager.audioBGM);
        volumeController.GetSourceAndUpdate(sfxVolumeSlider, audioManager.audioSFX);
    }
}
