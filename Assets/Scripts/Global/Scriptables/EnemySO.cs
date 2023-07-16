using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public StatsSO enemyStats;
    public GameObject enemyPrefab;
    public int rewardGold;
    public List<ItemSO> rewardItems;
}
