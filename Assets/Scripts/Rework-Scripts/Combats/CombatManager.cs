using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] EnemyScriptable enemyAttributes;
    [SerializeField] PlayerScriptable playerAttributes;
    [SerializeField] bool isEnemyDead = false;
    [SerializeField] bool isPlayerDead = false;

    private void Start()
    {
        enemyAttributes.SetHealth();
        playerAttributes.SetHealth();

        InvokeRepeating("PlayerDamageReceive", 0, (float)enemyAttributes.baseAttackSpeed);
    }
   
    private void OnEnable()
    {
        EnemyHitBox.takeHit += EnemyDamageReceive;
    }

    private void PlayerDamageReceive()
    {
        //put enemy attack animation here
        playerAttributes.currentHealth -= enemyAttributes.baseAttack;
        //put player animation damage taken here
        //put player audio damage taken here
        DeadChecker();
    }

    private void EnemyDamageReceive()
    {
        //put player attack animation here
        enemyAttributes.currentHealth -= playerAttributes.baseAttack;
        //put enemy animation damage taken here
        //put enemy audio damage taken here
        DeadChecker();
    }

    private void DeadChecker()
    {
        if(enemyAttributes.currentHealth < 0)
        {
            //put enemy death animation and/or audio here
            //put player victor animation and/or audio here
            Debug.Log("You defeated the enemy!");
            isEnemyDead = true;
            CombatResult();
        }

        if(playerAttributes.currentHealth < 0)
        {
            //put player death animation and/or audio here
            //put enemy victor animation and/or audio here
            Debug.Log("You died!");
            isPlayerDead = true;
            CombatResult();
        }
    }

    private void CombatResult()
    {
        if(isEnemyDead && !isPlayerDead)
        {
            //Put Deafetead UI here
            Debug.Log("Game Over. Should return you to the Hub now.");
            //put sceneloader here
        }

        if (!isEnemyDead && isPlayerDead)
        {
            //put Victor Result UI here
            Debug.Log("Giving you rewards.");
            //put sceneloader here
        }
    }

}
