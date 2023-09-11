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
        yield return new WaitForSeconds(enemyNextSpawnTime);

        if(enemyIndex < enemyList.Count)
        {
            enemyList[enemyIndex].SetActive(true);
            enemyIndex++;
        }
        else
        {
            Debug.Log("All enemies are defeated.");
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
