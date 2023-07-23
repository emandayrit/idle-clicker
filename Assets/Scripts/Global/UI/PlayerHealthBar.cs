using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] TMP_Text hpText;
    [SerializeField] StatsSO player;

    private void Awake() => SetUI(player.maxHP);

    private void SetUI(int _value)
    {
        hpSlider.maxValue = _value;
        hpSlider.value = _value;
        hpText.text = $"{_value}/{_value}";
    }

    public void SetHealthBar(int _damage)
    {
        hpSlider.value = player.currentHp;
        hpText.text = $"{player.currentHp}/{player.maxHP}";
    }
}
