
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    AudioManager manager;

    private void Start()
    {
        if(manager != null)
        {
            manager = FindAnyObjectByType<AudioManager>();
        }
    }

    public void PlaySound(string name)
    {
        if (manager != null)
        {
            manager.PlaySFX(name);
        }
    }
}
