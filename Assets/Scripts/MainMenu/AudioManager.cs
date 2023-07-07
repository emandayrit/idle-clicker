
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Audio[] audioBGM, audioSFX;

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

        AddAudioSource(audioBGM);
        AddAudioSource(audioSFX);
    }

    public void AddAudioSource(Audio[] audios)
    {
        foreach(Audio a in audios)
        {
            a.audioSource = gameObject.AddComponent<AudioSource>();
            a.audioSource.clip = a.audioClip;
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

        bgm.audioSource.clip = bgm.audioClip;
        bgm.audioSource.Play();
    }

    public void PlaySFX(string name)
    {
        Audio sfx = Array.Find(audioSFX, a => a.audioName == name);
        if (sfx == null) return;
        sfx.audioSource.PlayOneShot(sfx.audioClip);
    }

}   
