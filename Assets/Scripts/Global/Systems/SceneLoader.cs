using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    AudioManager audioManager;
    private string audioName;

    ButtonChangeScene buttonChange;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        buttonChange = FindAnyObjectByType<ButtonChangeScene>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneIndex = scene.buildIndex;

        switch(sceneIndex)
        {
            case 0:
                audioName = "Komiku";

                if(!buttonChange.isChangeSceneActivated())
                {
                    audioManager.PlayBGM(audioName, false);
                    break;
                }

                audioManager.PlayBGM(audioName, true);
                break;
            case 1:
                audioName = "Battle";
                audioManager.PlayBGM(audioName, true);
                break;
            case 2:
                break;
        }
    }

    public string GetAudioName()
    {
        return audioName;
    }
}
