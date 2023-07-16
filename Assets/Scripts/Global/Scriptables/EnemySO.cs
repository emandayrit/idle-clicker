using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Scriptable", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public enum EnemyType { Normal,Unique,Boss};

    [Header("For Status")]
    public bool isEnemyDead = false;
    public EnemyType enemyType;
    public string enemyName;
    public int enemyLevel;
    public GameObject enemyBody;

    [Header("For Attributes")] //default attributes
    public float maxHP = 100;
    public float health = 100;
    public float damage = 2;
    public float defense = 0;
    [Tooltip("1 is equal to 100%")]
    public float critChance = 0.05f;
    [Tooltip("1 is equal to 100%")]
    public float critDamage = 1.25f;
    [Tooltip("1 is equal to 100%")]
    public float evasion = 0.01f;

    [Header("For Skills")]
    public List<ScriptableObject> activeSkills;
    public List<ScriptableObject> passiveSkills;

    [Header("For Rewards")]
    public float goldReward;
    public float expReward;
    public List<ScriptableObject> rewards;

    public void ResetHealth()
    {
        health = maxHP;
    }

    


}
