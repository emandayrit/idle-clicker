
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    AudioManager manager;

    private void Start()
    {
        manager = FindAnyObjectByType<AudioManager>();
    }

    public void PlaySound(string name)
    {
        manager.PlaySFX(name);
    }
}
