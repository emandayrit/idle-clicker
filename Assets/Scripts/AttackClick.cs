using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClick : MonoBehaviour
{
    [SerializeField] KeyCode attackInput = KeyCode.Mouse0;

    [SerializeField] GameObject weaponArm;
    [SerializeField] GameObject enemyBody;

    void Update()
    {
        ClickAttack();
    }

    void ClickAttack()
    {
        if (Input.GetKeyDown(attackInput))
        {
            Debug.Log($"you clicked!");
            weaponArm.GetComponent<Animator>().SetTrigger("Attack");
            enemyBody.GetComponent<Animator>().SetTrigger("Hurt");
        }
    }
}
