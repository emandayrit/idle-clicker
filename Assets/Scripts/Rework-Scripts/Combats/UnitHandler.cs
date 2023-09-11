using UnityEngine;

public enum UnitType { HERO,ENEMY,BOSS }

//For storing Player or Enemy variables
public class UnitHandler : MonoBehaviour
{
    public string unitName;
    public UnitType unitType;

    public RewardScriptable rewards; //only for enemy or boss
    public AttributeScriptable attributes;
    
    private void Awake()
    {
        SetHealth();
    }

    private void OnEnable()
    {
        SetHealth();
    }

    public void SetHealth()
    {
        attributes.currentHealth = attributes.maxHealth;
    }

    public void TakeDamage(double damage)
    {
        attributes.currentHealth -= damage; //put damage and defense calculation here
    }

}
