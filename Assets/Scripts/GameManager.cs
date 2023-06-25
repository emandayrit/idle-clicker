using System;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] KeyCode clickerInput = KeyCode.Space;
    [SerializeField] float clickCounter = 0;

    [SerializeField,Tooltip("The lower the value the slower the click count.")]
    float clickHoldSpeed = 3; 

    private void Update()
    {
        if (Input.GetKey(clickerInput))
        {
            clickCounter += clickHoldSpeed * Time.deltaTime;
            Debug.Log($"you clicked {math.ceil(clickCounter)}");
        }
    }
}
