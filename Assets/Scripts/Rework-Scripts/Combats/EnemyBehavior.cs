using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IDamageable
{
    private UnitHandler enemyHandler;
    private UnitHandler playerHandler;

    private void Awake()
    {
        InitializeHandlers();
    }

    private void Start()
    {
        StartCoroutine(EnemyAttack((float)enemyHandler.attributes.baseSpeed));
    }

    IEnumerator EnemyAttack(float waitInSecond)
    {
        while(playerHandler.attributes.currentHealth > 0)
        {
            yield return new WaitForSeconds(waitInSecond);
            
            TakeDamage(playerHandler,enemyHandler);
        }
    }

    public void TakeDamage(UnitHandler player, UnitHandler enemy)
    {
        if (player.attributes.currentHealth > 0)
        {
            player.TakeDamage(enemy.attributes.baseDamage);
        }
    }

    private void InitializeHandlers()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHandler = player.GetComponent<UnitHandler>();
        enemyHandler = GetComponent<UnitHandler>();
    }

}
