using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Players")]
public class PlayerScriptable : ScriptableObject
{
    public string playerName;

    [Header("Currency")]
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
}
