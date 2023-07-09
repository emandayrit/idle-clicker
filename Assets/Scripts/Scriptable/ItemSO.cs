using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public enum itemType{ Consumable, Weapon, Armor, Material }

    public string itemName;
    public int itemPrice;

    [Header("For Consumable")]
    public int healAmount;

    [Header("For Weapon/Armor")]
    public int attackIncrease;
    public int healthIncrease;
}
