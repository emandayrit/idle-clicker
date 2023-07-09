using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] KeyCode clickerClick;
    [SerializeField] float clickCounter = 0;
    [SerializeField] GameObject playerArm;

    private Animator attackAnimation;

    private void Start()
    {
        attackAnimation = playerArm.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(clickerClick))
        {
            Debug.Log($"you clicked {clickCounter++}");
            attackAnimation.SetTrigger("Attack");
        }
    }
}
