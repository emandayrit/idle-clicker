using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Image hpBar;
    [SerializeField] TMP_Text hpBarText;
    [SerializeField] StatsValue value;


    private void Awake()
    {
        hpBar.fillAmount = 1;
        UpdateHPBarText();
    }

    private void OnEnable() => AttackClick.attackAction += EnemyDamage;

    private void OnDisable() => AttackClick.attackAction -= EnemyDamage;


    void LateUpdate()
    {
        UpdateHPBarText();
    }

    void EnemyDamage(int _damage)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            float damageBar = (float)(value.currentHp-1) / (float)value.maxHP;
            hpBar.fillAmount = damageBar;
            Debug.Log(damageBar);
        }
    }

    void UpdateHPBarText()
    {
        hpBarText.text = $"{value.currentHp}/{value.maxHP}";
    }
}
