using System.Collections.Generic;
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
    public float playerExp;

    [Header("For Attributes")] //default attributes
    public float maxHP = 20;
    public float health = 20;
    public float stamina = 0;
    public float damage = 1;
    public float defense = 0;
    [Tooltip("1 is equal to 100%")]
    public float critChance = 0.05f;
    [Tooltip("1 is equal to 100%")]
    public float critDamage = 1.25f;
    [Tooltip("1 is equal to 100%")]
    public float evasion = 0.01f;

    [Header("For Skills")]
    public List<ScriptableObject> activeSkills;
    public List<ScriptableObject> passiveSkills;

    public void ResetHealth()
    {
        health = maxHP;
    }

    public void AddActiveSkill(ScriptableObject _skill)
    {
        activeSkills.Add(_skill);
    }

    public void AddPassiveSkill(ScriptableObject _skill)
    {
        passiveSkills.Add(_skill);
    }
}
