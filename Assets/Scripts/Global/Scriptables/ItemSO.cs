using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Scriptables", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    [Header("For Item Status")]
    public ItemType itemType;
    public Sprite itemIcon;
    public string itemName;
    public int itemPrice = 1; //default price

    [Header("For Weapon")]
    public int weaponLevel;
    public int damageFlat;
    [Tooltip("1 is equal to 100%")]
    public float damagePercent;
    [Tooltip("1 is equal to 100%")]
    public float critChancePercent;
    [Tooltip("1 is equal to 100%")]
    public float critDamagePercent;

    [Header("For Armor")]
    public int armorLevel;
    public int maxHPFlat;
    [Tooltip("1 is equal to 100%")]
    public float maxHPPercent;
    public int defenseFlat;
    [Tooltip("1 is equal to 100%")]
    public float defensePercent;
    [Tooltip("1 is equal to 100%")]
    public float evasionPercent;

    public void RemoveItem(string _itemName)
    {
        if (_itemName == itemName)
        {
            //do remove the item in the inventory or something.
        }
    }

    public void ArmorLevelUp()
    {
        armorLevel += 1;
    }

    public void WeaponLevelUp()
    {
        weaponLevel += 1;
    }
    
    //for enums holder
    public enum ItemType{ Weapon,Armor,Material }
}
