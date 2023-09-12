using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Attributes")]
public class AttributeScriptable : ScriptableObject
{
    [Header("Base Attributes")]
    public double level;
    public double maxHealth;
    public double currentHealth;
    public double baseDamage;
    public double baseSpeed;
    public double baseDefense;
    public double baseCritical;
    public double baseCriticalDamage;


    [Header("Modified Attributes")]
    public double mMaxHealth;
    public double mCurrentHealth;
    public double mBaseDamage;
    public double mBaseSpeed;
    public double mBaseDefense;
    public double mBaseCritical;
    public double mBaseCriticalDamage;

    public void SetAttributesByLevel(double level)
    {
        this.level = level;
        mMaxHealth = level * maxHealth;
        mCurrentHealth = mMaxHealth;
        mBaseDamage = level * baseDamage;
        mBaseSpeed = level * baseSpeed;
        mBaseDefense = level * baseDefense;
        mBaseCritical = level * baseCritical;
        mBaseCriticalDamage = level * baseCriticalDamage;
    }
}
