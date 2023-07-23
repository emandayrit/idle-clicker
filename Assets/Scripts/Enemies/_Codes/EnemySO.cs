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
    public double maxHP = 100;
    public double currentHp = 100;
    public double damage = 3;
    public double defense = 0;
    [Tooltip("1 is equal to 100%")]
    public double critChance = 0.1f;
    [Tooltip("1 is equal to 100%")]
    public double critDamage = 1.25f;

    [Header("For Rewards")]
    public double goldReward;
    public double expReward;

    public void ResetHealth()
    {
        currentHp = maxHP;
    }

    


}
