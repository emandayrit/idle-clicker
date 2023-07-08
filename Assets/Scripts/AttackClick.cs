using System;
using TMPro;
using UnityEngine;

public class AttackClick : MonoBehaviour
{
    [SerializeField] KeyCode attackInput = KeyCode.Mouse0;
    KeyCode kc;

    [SerializeField] GameObject weaponArm;
    [SerializeField] GameObject enemyBody;

    [SerializeField] StatsValue playerStats;

    [Header ("UI Objects")]
    [SerializeField] GameObject playerHitTextUI;
    [SerializeField] GameObject playerHitParentUI;

    public static event Action<int> attackAction;

    private GameObject _enemy;

    KeyBindManager test;

    private void Awake()
    {
  
        _enemy = FindObjectOfType<Stats>().transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        test = FindAnyObjectByType<KeyBindManager>();
        kc = test.attackKey;
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

    bool CanAttack() => (_enemy.activeInHierarchy && Input.GetKeyDown(kc)) ? true : false;

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
