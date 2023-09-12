using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private UnitHandler enemyHandler;
    private UnitHandler playerHandler;

    private void Awake()
    {
        InitializeHandlers();
    }

    private void Start()
    {
        StartCoroutine(EnemyAttack((float)enemyHandler.attributes.mBaseSpeed));
    }

    IEnumerator EnemyAttack(float waitInSecond)
    {
        while(playerHandler.attributes.mCurrentHealth > 0)
        {
            
            yield return new WaitForSeconds(waitInSecond);
            
            playerHandler.TakeDamage(enemyHandler);
        }

        Debug.Log("Player is dead");
        CombatResult.PlayerDefeated();
    }

    private void InitializeHandlers()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHandler = player.GetComponent<UnitHandler>();
        enemyHandler = GetComponent<UnitHandler>();
    }

}
