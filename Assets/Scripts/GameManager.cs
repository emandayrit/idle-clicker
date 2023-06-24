using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] KeyCode clickerInput = KeyCode.Space;
    [SerializeField] int clickCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(clickerInput))
        {
            Debug.Log($"you clicked {++clickCount}");
        }
    }
}
