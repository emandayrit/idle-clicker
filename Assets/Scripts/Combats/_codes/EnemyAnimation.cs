using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAnimation : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] Animator enemyAnimator;
    [SerializeField] GameObject victoryUI;
    [SerializeField] float exitCombatInSeconds = 3;

    [Header("PopUp Damage")]
    [SerializeField] GameObject popUpDamageParent;
    [SerializeField] GameObject popUpDamagePrefab;

    [Header("Scriptable")]
    [SerializeField] EnemySO enemy;

    private void OnEnable() => PlayerAttack.action += EnemyHurt;

    private void OnDisable() => PlayerAttack.action -= EnemyHurt;


    private void EnemyHurt(double _damage)
    {
        enemyAnimator.SetTrigger("Hurt");
        ShowPopUpDamageUI(_damage);
        EnemyDefeated();
    }

    private void EnemyDefeated()
    {
        if (IsEnemyDead())
        {
            StartCoroutine(EnemyDefeatedCoroutine());
        }
    }

    IEnumerator EnemyDefeatedCoroutine()
    {
        PlayerAttack.canPlayerAttack = false;
        enemyAnimator.SetTrigger("Death");
        victoryUI.SetActive(true);

        yield return new WaitForSeconds(exitCombatInSeconds);
        SceneManager.LoadScene(1); //0 = Main Menu, 1 = Game Scene, 2 = Combat Scene
    }

    private void ShowPopUpDamageUI(double _damage)
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
    bool IsEnemyDead() => (enemy.currentHp <= 0) ? true : false;
}
