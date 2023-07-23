using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Scriptables", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Item Status")]
    public Sprite itemIcon;
    public string itemName;

    [Header("For Weapon")]
    public Rank currentRank = Rank.F;
    public double rankDamageBonus = 1;
    public double weaponLevel = 1;
    public double weaponDamage = 1;

    [Header("For Quantity")]
    public double currentQuantity = 1;

    public void WeaponLevelUp()
    {
        weaponLevel += 1;
    }

    public void WeaponRankUp()
    {
        currentRank++;
    }

    //for enums holder
    public enum Rank { F,E,D,C,B,A,S,SS,SSS,Ultimate }
}
