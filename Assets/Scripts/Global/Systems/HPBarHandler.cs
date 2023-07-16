using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarHandler : MonoBehaviour
{
    [SerializeField] Image hpBar;
    [SerializeField] TMP_Text hpBarText;
    [SerializeField] StatsSO value;
    
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
            float damageBar = (float)(value.currentHp) / (float)value.maxHP;
            hpBar.fillAmount = damageBar;
            Debug.Log(damageBar);
        }
    }

    void UpdateHPBarText()
    {
        float _value = (value.currentHp <= 0) ? 0 : value.currentHp;
        hpBarText.text = $"{_value}/{value.maxHP}";
    }
}
