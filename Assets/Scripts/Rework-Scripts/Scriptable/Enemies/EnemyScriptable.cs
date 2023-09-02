using UnityEngine;


[CreateAssetMenu(menuName ="Scriptable/Enemies")]
public class EnemyScriptable : ScriptableObject
{
    public string enemyName;
    public EnemyType enemyType;

    [Header("Rewards")]
    public double baseExperience;
    public double baseCurrency;
    public double baseMaterial;

    [Header("Attributes")]
    public double level;
    public double maxHealth;
    public double currentHealth;
    public double baseAttack;
    public double baseAttackSpeed;
    public double baseDefense;
    public double baseCritical;
    public double baseCriticalDamage;



    public void SetHealth()
    {
        currentHealth = maxHealth;
    }

    public enum EnemyType {Normal, Unique, Boss}
}
