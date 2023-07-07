using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class ButtonChangeScene : MonoBehaviour
{

    public int sceneIndex;
    AudioManager manager;
    AudioFader fader;

    private void Start()
    {
        manager = FindAnyObjectByType<AudioManager>();
        fader = FindAnyObjectByType<AudioFader>();
    }

    public void OnButtonClicked()
    {
        if (sceneIndex < 0 && sceneIndex > SceneManager.sceneCountInBuildSettings)
            return;

        Audio bgm = Array.Find(manager.audioBGM, a => a.audioName == manager.bgmName);
        if (bgm == null) return;

        Debug.Log("adqweas " + bgm.audioSource.volume);

        fader.FadeOut(bgm);
        SceneManager.LoadScene(sceneIndex);
    }
}
