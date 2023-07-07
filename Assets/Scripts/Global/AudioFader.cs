using System;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    public float fadeDuration;

    public void FadeOut(Audio audio)
    {
        StartCoroutine(FadeOutCoroutine(audio));
    }

    private System.Collections.IEnumerator FadeOutCoroutine(Audio audio)
    {
        float elapsedTime = 0.0f;
        float startVolume = audio.audioSource.volume;

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
