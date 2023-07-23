using UnityEngine;

[CreateAssetMenu(fileName = "Player Scriptable", menuName = "Player")]
public class PlayerSO : ScriptableObject
{
    [Header("For Status")]
    public bool isPlayerDead = false;
    public string playerName;
    public GameObject playerBody;

    [Header("For Prestige")]
    public int playerLevel;
    public double playerExp;

    [Header("For Attributes")] //default attributes
    public double maxHP = 30;
    public double health = 30;
    public double stamina = 0;
    public double damage = 1;
    public double defense = 0;
    [Tooltip("1 is equal to 100%")]
    public double critChance = 0.1f;

    [Header("For Equipments")]
    public WeaponSO playerWeaponSlot;
    public ArmorSO playerArmorSlot;

    [Header("For Skills")]
    public int autoClickLevel = 0;
    public int autoClickDamage = 1;

    public void ResetHealth()
    {
        health = maxHP;
    }
}
