using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] TMP_Text hpText;
    [SerializeField] PlayerSO player;

    private void Awake() => SetUI(player.maxHP);

    private void SetUI(double _value)
    {
        hpSlider.maxValue = (float)_value;
        hpSlider.value = (float)_value;
        hpText.text = $"{_value}/{_value}";
    }

    public void SetPlayerSliderHealth(double _damage)
    {
        hpSlider.value = (float)player.currentHp;
        hpText.text = $"{player.currentHp}/{player.maxHP}";
    }
}
