using System;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    private UnitHandler enemyHandler;
    private UnitHandler playerHandler;
    private EnemyRespawn enemyRespawn;

    private void Awake()
    {
        InitializeHandlers();
    }

    private void OnMouseDown()
    {
        enemyHandler.TakeDamage(playerHandler.attributes.baseDamage);

        if (enemyHandler.attributes.currentHealth < 0)
        {
            enemyRespawn.EnemyDefeated(gameObject);
        }
    }

    private void InitializeHandlers()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHandler = player.GetComponent<UnitHandler>();
        enemyHandler = GetComponent<UnitHandler>();
        enemyRespawn = transform.parent.GetComponent<EnemyRespawn>();
    }
}
