
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public Audio[] audioBGM, audioSFX;
    float fadeDuration;

    public string bgmName;

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
        AddAudioSource(audioBGM);
        AddAudioSource(audioSFX);
    }

    private void Start()
    {
        //PlayBGM("Komiku", false);
    }


    public void AddAudioSource(Audio[] audios)
    {
        foreach(Audio a in audios)
        {
            a.audioSource = gameObject.AddComponent<AudioSource>();
            a.audioSource.loop = true;
            a.audioSource.clip = a.audioClip;
        }
    }

    public void PlayBGM(string name, bool isFadeIn)
    {
        Audio bgm = Array.Find(audioBGM, a => a.audioName == name);
        if (bgm == null) return;

        bgm.audioSource.clip = bgm.audioClip;

        if (!isFadeIn)
        {
            bgm.audioSource.Play();
            return;
        }

        FadeIn(bgm);
    }

    public void PlaySFX(string name)
    {
        Audio sfx = Array.Find(audioSFX, a => a.audioName == name);
        if (sfx == null) return;

        sfx.audioSource.PlayOneShot(sfx.audioClip);
    }



    public void StopBGM(string name, bool isFadeOut)
    {
        Audio bgm = Array.Find(audioBGM, a => a.audioName == name);
        if (bgm == null) return;
        bgm.audioSource.clip = bgm.audioClip;

        if (!isFadeOut)
        {
            bgm.audioSource.Stop();
            return;
        }

        FadeOut(bgm);
    }



    public void FadeOut(Audio audio)
    {
        StartCoroutine(FadeOutCoroutine(audio));
    }

    private System.Collections.IEnumerator FadeOutCoroutine(Audio audio)
    {
        float elapsedTime = 0.0f;
        float startVolume = audio.audioSource.volume;
        fadeDuration = audio.audioSource.volume;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audio.audioSource.volume = Mathf.Lerp(startVolume, 0.0f, elapsedTime / fadeDuration);
            yield return null;
        }

        audio.audioSource.Stop();
        audio.audioSource.volume = startVolume;
    }


    public void FadeIn(Audio audio)
    {
        StartCoroutine(FadeInCoroutine(audio));
    }



    private System.Collections.IEnumerator FadeInCoroutine(Audio audio)
    {
        float elapsedTime = 0.0f;
        float targetVolume = audio.audioSource.volume;
        fadeDuration = 1.0f;

        audio.audioSource.volume = 0.0f;
        audio.audioSource.PlayDelayed(1.5f);
        audio.audioSource.Play();

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audio.audioSource.volume = Mathf.Lerp(0.0f, targetVolume, elapsedTime / fadeDuration);
            yield return null;
        }

        audio.audioSource.volume = targetVolume;
    }
}   
