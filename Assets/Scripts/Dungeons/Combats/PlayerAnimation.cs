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
    [SerializeField] GameObject playerHitTextPrefab;
    [SerializeField] GameObject playerHitTextParent;

    [Header("Scriptable")]
    [SerializeField] StatsSO player;

    private void OnEnable() => Attacking.action += StartWeaponAnimation;

    private void OnDisable() => Attacking.action -= StartWeaponAnimation;

    private void StartWeaponAnimation(int _value)
    {
        playerWeapon.GetComponent<Animator>().SetTrigger("Attack");
    }

    private void EnemyDefeated()
    {
        if (IsPlayerDead())
        {
            StartCoroutine(EnemyDefeatedCoroutine(exitCombatInSeconds));
        }
    }

    IEnumerator EnemyDefeatedCoroutine(float _seconds)
    {
        Attacking.canAttack = true;

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
            GameObject hitUI = Instantiate(playerHitTextPrefab, playerHitTextParent.transform);
            hitUI.GetComponent<TMP_Text>().text = $"-{_damage}";
            Destroy(hitUI, 1);
        }
    }

    //For readable booleans
    bool IsUIAvailable() => (playerHitTextPrefab && playerHitTextParent) ? true : false;
    bool IsPlayerDead() => (player.currentHp <= 0) ? true : false;
}
