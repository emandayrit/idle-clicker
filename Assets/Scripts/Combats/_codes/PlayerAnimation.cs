using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject defeatUI;
    [SerializeField] float exitCombatInSeconds = 3;

    [Header("PopUp Damage")]
    [SerializeField] GameObject popUpDamageParent;
    [SerializeField] GameObject popUpDamagePrefab;

    [Header("Scriptable")]
    [SerializeField] PlayerSO player;

    private void OnEnable() => PlayerAttack.action += StartWeaponAnimation;

    private void OnDisable() => PlayerAttack.action -= StartWeaponAnimation;

    private void StartWeaponAnimation(double _value)
    {
        playerAnimator.SetTrigger("Attack");
    }

    private void PlayerDefeated()
    {
        if (IsPlayerDead())
        {
            StartCoroutine(PlayerDefeatedCoroutine());
        }
    }

    IEnumerator PlayerDefeatedCoroutine()
    {
        PlayerAttack.canPlayerAttack = false;
        playerAnimator.SetTrigger("Death");
        defeatUI.SetActive(true);

        yield return new WaitForSeconds(exitCombatInSeconds);
        SceneManager.LoadScene(1); //0 = Main Menu, 1 = Game Scene, 2 = Combat Scene
    }

    //when player is taking damage
    private void HitPopUpUI(int _damage)
    {
        if (IsPopUpPresent())
        {
            GameObject hitUI = Instantiate(popUpDamagePrefab, popUpDamageParent.transform);
            hitUI.GetComponent<TMP_Text>().text = $"-{_damage}";
            Destroy(hitUI, 1);
        }
    }

    //For readable booleans
    bool IsPopUpPresent() => (popUpDamagePrefab && popUpDamageParent) ? true : false;
    bool IsPlayerDead() => (player.currentHp <= 0) ? true : false;
}
