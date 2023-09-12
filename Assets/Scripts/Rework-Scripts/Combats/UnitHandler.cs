using UnityEngine;

public enum UnitType { HERO,ENEMY,BOSS }

//For storing Player or Enemy variables
public class UnitHandler : MonoBehaviour
{
    public string unitName;
    public UnitType unitType;
    public double unitLevel;

    public RewardScriptable rewards; //only for enemy or boss
    public AttributeScriptable attributes;
    
    private void Awake()
    {
        SetHealth();
        attributes.SetAttributesByLevel(unitLevel);
    }

    private void OnEnable()
    {
        SetHealth();
    }

    public void SetHealth()
    {
        attributes.mCurrentHealth = attributes.mMaxHealth;
    }

    public void TakeDamage(UnitHandler attacker)
    {
        attributes.mCurrentHealth -= attacker.attributes.mBaseDamage; //put damage and defense calculation here
    }

}
