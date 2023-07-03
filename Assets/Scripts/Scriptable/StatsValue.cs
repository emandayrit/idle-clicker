using System.Numerics;
using UnityEngine;

[CreateAssetMenu (fileName = "Stats")]
public class StatsValue : ScriptableObject
{
    public int maxHP;
    public int currentHp;
    public int attack;
    public float attackSpeed; //only for enemies

    public void InitializeEnemyHP()
    {
        currentHp = maxHP;
    }
}