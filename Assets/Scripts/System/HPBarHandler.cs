using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarHandler : MonoBehaviour
{
    [SerializeField] Image hpBar;
    [SerializeField] TMP_Text hpBarText;
    [SerializeField] StatsValue value;
    
    private void Awake()
    {
        hpBar.fillAmount = 1;
        UpdateHPBarText();
    }

    private void OnEnable() => PlayerAttack.attackAction += CalculateEnemyHPBar;

    private void OnDisable() => PlayerAttack.attackAction -= CalculateEnemyHPBar;

    void LateUpdate()
    {
        UpdateHPBarText();
    }

    void CalculateEnemyHPBar(int _damage)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            float damageBar = (float)(value.currentHp-1) / (float)value.maxHP;
            hpBar.fillAmount = damageBar;
        }
    }

    void UpdateHPBarText()
    {
        hpBarText.text = $"{value.currentHp}/{value.maxHP}";
    }
}
