using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable/Rewards")]
public class RewardScriptable : ScriptableObject
{
    [Header("Rewards")]
    public double baseExperience;
    public double baseCurrency;
    public double baseMaterial;
}
