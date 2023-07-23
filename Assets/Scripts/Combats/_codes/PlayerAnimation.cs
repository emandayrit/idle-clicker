using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Player Object")]
    [SerializeField] GameObject playerWeapon;
    [SerializeField] Animator playerDeathAnimation;
    [SerializeField] GameObject defeatUI;
    [SerializeField] float exitCombatInSeconds = 3;

    [Header("Hit UI Objects")]
    [SerializeField] GameObject enemyHitTextPrefab;
    [SerializeField] GameObject enemyHitTextParent;

    [Header("Scriptable")]
    [SerializeField] PlayerSO player;

    private void OnEnable() => PlayerAttack.action += StartWeaponAnimation;

    private void OnDisable() => PlayerAttack.action -= StartWeaponAnimation;

    private void StartWeaponAnimation(double _value)
    {
        playerWeapon.GetComponent<Animator>().SetTrigger("Attack");
    }

    private void PlayerDefeated()
    {
        if (IsPlayerDead())
        {
            StartCoroutine(PlayerDefeatedCoroutine(exitCombatInSeconds));
        }
    }

    IEnumerator PlayerDefeatedCoroutine(float _seconds)
    {
        PlayerAttack.canPlayerAttack = false;

        playerDeathAnimation.SetTrigger("Death");
        defeatUI.SetActive(true);

        yield return new WaitForSeconds(_seconds);

        SceneManager.LoadScene(1); //0 = Main Menu, 1 = Game Scene, 2 = Combat Scene
    }

    //when player is taking damage
    private void HitPopUpUI(int _damage)
    {
        if (IsUIAvailable())
        {
            GameObject hitUI = Instantiate(enemyHitTextPrefab, enemyHitTextParent.transform);
            hitUI.GetComponent<TMP_Text>().text = $"-{_damage}";
            Destroy(hitUI, 1);
        }
    }

    //For readable booleans
    bool IsUIAvailable() => (enemyHitTextPrefab && enemyHitTextParent) ? true : false;
    bool IsPlayerDead() => (player.currentHp <= 0) ? true : false;
}
