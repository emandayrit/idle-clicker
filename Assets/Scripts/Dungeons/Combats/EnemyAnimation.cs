using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAnimation : MonoBehaviour
{
    [Header("Enemy Object")]
    [SerializeField] GameObject enemyBody;
    [SerializeField] Animator enemyDeathAnimation;
    [SerializeField] GameObject victoryUI;
    [SerializeField] float exitCombatInSeconds = 3;

    [Header("UI Objects")]
    [SerializeField] GameObject playerHitTextUI;
    [SerializeField] GameObject playerHitParentUI;

    [Header("Scriptable")]
    [SerializeField] StatsSO enemy;

    private void OnEnable() => Attacking.action += EnemyHurt;

    private void OnDisable() => Attacking.action -= EnemyHurt;

    private void EnemyHurt(int _damage)
    {
        enemyBody.GetComponent<Animator>().SetTrigger("Hurt");
        HitPopUpUI(_damage);

        EnemyDefeated();
    }

    private void EnemyDefeated()
    {
        if (IsEnemyDead())
        {
            StartCoroutine(EnemyDefeatedCoroutine(exitCombatInSeconds));
        }
    }

    IEnumerator EnemyDefeatedCoroutine(float _seconds)
    {
        Attacking.canAttack = true;

        enemyDeathAnimation.SetTrigger("Death");
        victoryUI.SetActive(true);

        yield return new WaitForSeconds(_seconds);

        SceneManager.LoadScene(1); //0 = Main Menu, 1 = Game Scene, 2 = Combat Scene
    }

    private void HitPopUpUI(int _damage)
    {
        if (IsUIAvailable())
        {
            GameObject hitUI = Instantiate(playerHitTextUI, playerHitParentUI.transform);
            hitUI.GetComponent<TMP_Text>().text = $"-{_damage}";
            Destroy(hitUI, 1);
        }
    }


    //For readable booleans
    bool IsUIAvailable() => (playerHitTextUI && playerHitParentUI) ? true : false;
    bool IsEnemyDead() => (enemy.currentHp <= 0) ? true : false;
}
