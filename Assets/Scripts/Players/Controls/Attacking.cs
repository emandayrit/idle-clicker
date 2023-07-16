using System;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    private KeyCode attackInput;
    private KeyBindManager bindManager;

    [SerializeField] StatsSO playerStats;

    public static bool canAttack;
    public static event Action<int> action;

    private void Start() => SetInputs();

    private void Update() => DoAttack();

    private void DoAttack()
    {
        if (IsAbleToAttack())
        {
            action?.Invoke(playerStats.attackDamage);
        }
    }

    private void SetInputs()
    {
        canAttack = false;
        bindManager = FindAnyObjectByType<KeyBindManager>();
        attackInput = bindManager.attackKey;
    }

    //For readable booleans
    bool IsAbleToAttack() => (!canAttack && Input.GetKeyDown(attackInput)) ? true : false;
}
