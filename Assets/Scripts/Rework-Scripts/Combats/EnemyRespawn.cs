using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public int enemyCount;
    public int enemyIndex;
    public float enemyNextSpawnTime;

    public GameObject enemyPrefab;
    private List<GameObject> enemyList = new List<GameObject>();

    private void Awake()
    {
        SetEnemyCount();
    }

    public void EnemyDefeated(GameObject enemy)
    {
        enemy.SetActive(false);
        StartCoroutine(SpawnNextEnemy());
    }

    IEnumerator SpawnNextEnemy()
    {
        GetReward();

        yield return new WaitForSeconds(enemyNextSpawnTime);

        GetNextEnemy();
    }

    private void GetReward()
    {
        EnemyReward reward = enemyList[enemyIndex-1].GetComponent<EnemyReward>();
        reward.GetRewards();

        CombatResult.TransferReward(reward.GiveCurrency(), reward.GiveExperience(), reward.GiveMaterial());
    }

    private void GetNextEnemy()
    {
        if (enemyIndex < enemyList.Count)
        {
            enemyList[enemyIndex].SetActive(true);
            enemyIndex++;
        }
        else
        {
            CombatResult.PlayerVictory();
        }
    }

    private void SetEnemyCount()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject temp = Instantiate(enemyPrefab,transform);
            temp.name = $"{enemyPrefab.name} {i}";
            temp.transform.parent = transform;
            temp.SetActive(false);

            enemyList.Add(temp);
        }

        //Initialize first enemy
        enemyList[enemyIndex].SetActive(true);
        enemyIndex++;
    }
}
