using UnityEngine;

[CreateAssetMenu(fileName = "Armor Scriptables", menuName = "Armor")]
public class ArmorSO : ScriptableObject
{
    [Header("Item Status")]
    public Sprite itemIcon;
    public string itemName;

    [Header("For Weapon")]
    public Rank currentRank = Rank.F;
    public double rankDamageBonus = 1;
    public double armorLevel = 1;
    public double armorHP = 10;

    [Header("For Quantity")]
    public double currentQuantity = 1;

    public void ArmorLevelUp()
    {
        armorLevel += 1;
    }

    public void ArmorRankUp()
    {
        currentRank++;
    }

    //for enums holder
    public enum Rank { F, E, D, C, B, A, S, SS, SSS, Ultimate }
}
