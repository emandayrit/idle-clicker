
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Audio[] audioBGM, audioSFX;
    public AudioSource bgmSource, sfxSource;


    private void Awake()
    {
        if(instance == null)
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
        PlayBGM("Komiku Test");
    }

    public void PlayBGM(string name)
    {
        Audio audio = Array.Find(audioBGM, audios => audios.audioName == name);
        if (audio == null) return;

        bgmSource.clip = audio.audioClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlaySFX(string name)
    {
        Audio audio = Array.Find(audioSFX, audios => audios.audioName == name);
        if (audio == null) return;

        sfxSource.PlayOneShot(audio.audioClip);
    }
}   
