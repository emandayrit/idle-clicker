using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] TMP_Text hpText;
    [SerializeField] StatsSO enemy;

    private void Awake() => SetUI(enemy.maxHP);

    private void OnEnable() => PlayerAttack.action += SetHealthBar;

    private void OnDisable() => PlayerAttack.action -= SetHealthBar;

    private void SetUI(int _value)
    {
        enemy.InitializeEnemyHP();

        hpSlider.maxValue = _value;
        hpSlider.value = _value;
        hpText.text = $"{_value}/{_value}";
    }

    public void SetHealthBar(int _damage)
    {
        enemy.currentHp -= _damage;
        hpSlider.value = enemy.currentHp;
        hpText.text = $"{enemy.currentHp}/{enemy.maxHP}";
    }
}
