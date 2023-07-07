
using System;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioManager audioManager;
    AudioFader audioFader;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        audioFader = FindAnyObjectByType<AudioFader>();
    }

    public void PlayBGM(string name, bool isFadeIn)
    {
        Audio bgm = Array.Find(audioManager.audioBGM, a => a.audioName == name);
        if (bgm == null) return;

        bgm.audioSource.clip = bgm.audioClip;

        Debug.Log("adas " + bgm.audioSource.volume);
        if(!isFadeIn)
        {
            bgm.audioSource.Play();
            return;
        }
        
        audioFader.FadeIn(bgm);
    }

    public void PlaySFX(string name)
    {
        Audio sfx = Array.Find(audioManager.audioSFX, a => a.audioName == name);
        if (sfx == null) return;
        sfx.audioSource.PlayOneShot(sfx.audioClip);
    }
}
