using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Attributes")]
public class AttributeScriptable : ScriptableObject
{
    [Header("Attributes")]
    public double level;
    public double maxHealth;
    public double currentHealth;
    public double baseDamage;
    public double baseSpeed;
    public double baseDefense;
    public double baseCritical;
    public double baseCriticalDamage;
}
