using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] TMP_Text hpText;
    [SerializeField] EnemySO enemy;

    private void Awake() => SetUI(enemy.maxHP);

    private void OnEnable() => PlayerAttack.action += SetEnemySliderHealth;

    private void OnDisable() => PlayerAttack.action -= SetEnemySliderHealth;

    private void SetUI(double _value)
    {
        enemy.ResetHealth();

        hpSlider.maxValue = (float)_value;

        hpSlider.value = (float)_value;
        hpText.text = $"{_value}/{_value}";
    }

    public void SetEnemySliderHealth(double _damage)
    {
        EnemyTakeDamage(_damage);

        hpSlider.value = (float)enemy.currentHp;
        hpText.text = $"{enemy.currentHp}/{enemy.maxHP}";
    }

    private void EnemyTakeDamage(double _damage)
    {
        enemy.currentHp -= _damage;
    }
}
