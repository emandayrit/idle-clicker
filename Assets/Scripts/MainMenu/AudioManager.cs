
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
        
        PlayBGM("Komiku"); 
    }

    public void PlayBGM(string name)
    {
        Audio bgm = Array.Find(audioBGM, a => a.audioName == name);
        if (bgm == null) return;

        bgmSource.clip = bgm.audioClip;
        bgmSource.Play();
    }

    public void PlaySFX(string name)
    {
        Audio sfx = Array.Find(audioSFX, a => a.audioName == name);
        if (sfx == null) return;

        sfxSource.PlayOneShot(sfx.audioClip);
    }

    
}   
