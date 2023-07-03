using System;
using TMPro;
using UnityEngine;

public class AttackClick : MonoBehaviour
{
    [SerializeField] KeyCode attackInput = KeyCode.Mouse0;

    [SerializeField] GameObject weaponArm;
    [SerializeField] GameObject enemyBody;

    [SerializeField] StatsValue playerStats;

    [Header ("UI Objects")]
    [SerializeField] GameObject playerHitTextUI;
    [SerializeField] GameObject playerHitParentUI;

    public static event Action<int> attackAction;

    private GameObject _enemy;

    private void Awake()
    {
        _enemy = FindObjectOfType<Stats>().transform.GetChild(0).gameObject;
    }

    void Update()
    {
        ClickAttack();
    }

    void ClickAttack()
    {
        if (CanAttack())
        {
            Debug.Log("attack!");
            attackAction?.Invoke(playerStats.attack); // Starts to listen to Stats script

            PlayerAnimation();
            EnemyAnimation();
        }
    }

    bool CanAttack() => (_enemy.activeInHierarchy && Input.GetKeyDown(attackInput)) ? true : false;

    void PlayerAnimation()
    {
        weaponArm.GetComponent<Animator>().SetTrigger("Attack");
    }

    void EnemyAnimation()
    {
        enemyBody.GetComponent<Animator>().SetTrigger("Hurt");

        if (playerHitTextUI && playerHitParentUI)
        {
            GameObject hitUI = Instantiate(playerHitTextUI, playerHitParentUI.transform);
            hitUI.GetComponent<TMP_Text>().text = $"-{playerStats.attack}";
            Destroy(hitUI, 1);
        }
    }

}
