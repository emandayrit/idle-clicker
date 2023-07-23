using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private KeyCode attackInput;
    private KeyBindManager bindManager;

    [SerializeField] PlayerSO player;
    public static event Action<double> action;
    public static bool canPlayerAttack = true;

    private void Start() => SetInputs();

    private void Update() => Attack();

    private void Attack()
    {
        if (canAttack())
        {
            action?.Invoke(player.damage);
        }
    }

    private void SetInputs()
    {
        canPlayerAttack = true;
        bindManager = FindAnyObjectByType<KeyBindManager>();
        attackInput = bindManager.attackKey;
    }

    //For readable booleans
    bool canAttack() => (canPlayerAttack && Input.GetKeyDown(attackInput)) ? true : false;
}
