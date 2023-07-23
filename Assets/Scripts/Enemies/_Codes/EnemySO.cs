using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Scriptable", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public enum EnemyType { Normal,Unique,Boss };

    [Header("For Status")]
    public bool isEnemyDead = false;
    public EnemyType enemyType;
    public string enemyName;
    public int enemyLevel;
    public GameObject enemyBody;

    [Header("For Attributes")] //default attributes
    public float maxHP = 100;
    public float health = 100;
    public float damage = 3;
    public float defense = 0;
    [Tooltip("1 is equal to 100%")]
    public float critChance = 0.1f;
    [Tooltip("1 is equal to 100%")]
    public float critDamage = 1.25f;

    [Header("For Rewards")]
    public float goldReward;
    public float expReward;

    public void ResetHealth()
    {
        health = maxHP;
    }

    


}
