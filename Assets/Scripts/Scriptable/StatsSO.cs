using UnityEngine;

[CreateAssetMenu (fileName = "StatsSO", menuName = "Stats")]
public class StatsSO : ScriptableObject
{
    public int level;
    public int maxHP;
    public int currentHp;
    public int attackDamage;

    [Header("For Enemy")]
    public float attackSpeed;
    public int expReward;

    public void InitializeEnemyHP()
    {
        currentHp = maxHP;
    }
}
