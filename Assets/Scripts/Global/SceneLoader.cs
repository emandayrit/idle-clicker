using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader instance;

    AudioPlayer audioPlayer;
    AudioManager audioManager;
    VolumeController volumeController;

    private void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
        audioManager = FindAnyObjectByType<AudioManager>();
        volumeController = FindAnyObjectByType<VolumeController>();


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
                audioPlayer.PlayBGM("Komiku", false);
                audioManager.bgmName = "Komiku";
                break;
            case 1:
                audioPlayer.PlayBGM("Battle", true);
                audioManager.bgmName = "Battle";
                break;
            case 2:
                break;
        }
    }

}
