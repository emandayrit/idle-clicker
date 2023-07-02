using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClick : MonoBehaviour
{
    [SerializeField] KeyCode attackInput = KeyCode.Mouse0;

    [SerializeField] GameObject weaponArm;
    [SerializeField] GameObject enemyBody;

    [Header ("UI Objects")]
    [SerializeField] GameObject playerHitTextUI;
    [SerializeField] GameObject playerHitParentUI;

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

            if (playerHitTextUI && playerHitParentUI)
            {
                GameObject hitUI = Instantiate(playerHitTextUI, playerHitParentUI.transform);
                Destroy(hitUI, 1);
            }
        }
    }
}
