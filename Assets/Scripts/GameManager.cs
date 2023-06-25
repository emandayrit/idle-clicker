using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] KeyCode clickerClick;
    [SerializeField] float clickCounter = 0;

    private void Update()
    {
        if (Input.GetKeyDown(clickerClick))
        {
            Debug.Log($"you clicked {clickCounter++}");
        }
    }

}
