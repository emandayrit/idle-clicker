
using UnityEngine;

[System.Serializable]
public class Audio
{
    public string audioName;
    public AudioClip audioClip;

    [HideInInspector]
    public AudioSource audioSource;
}
