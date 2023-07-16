using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class ButtonChangeScene : MonoBehaviour
{
    private bool isChangeScene = false;

    AudioManager manager;
    SceneLoader loader;
    private void Start()
    {
        manager = FindAnyObjectByType<AudioManager>();
        loader = FindAnyObjectByType<SceneLoader>();
    }

    public void ChangeScene(int sceneIndex)
    {
        if (sceneIndex < 0 && sceneIndex > SceneManager.sceneCountInBuildSettings)
            return;

        manager.StopBGM(loader.GetAudioName(), true);
        isChangeScene = true;
        SceneManager.LoadScene(sceneIndex);
    }

    public bool isChangeSceneActivated()
    {
        return isChangeScene;
    }
}
