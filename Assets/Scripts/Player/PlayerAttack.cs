using System;
using TMPro;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] KeyCode attackInput = KeyCode.Mouse0;
    KeyCode kc;

    [SerializeField] GameObject weaponArm;
    [SerializeField] GameObject enemyBody;

    [SerializeField] StatsSO playerStats;

    [Header ("UI Objects")]
    [SerializeField] GameObject playerHitTextUI;
    [SerializeField] GameObject playerHitParentUI;

    public static event Action<int> attackAction;
    public bool isEnemyDead;

    private GameObject _enemy;

    KeyBindManager test;

    private void Awake()
    {
        _enemy = FindObjectOfType<Stats>().transform.GetChild(0).gameObject; //might need to change soon
    }

    private void Start()
    {
        isEnemyDead = false;
        test = FindAnyObjectByType<KeyBindManager>();
        kc = test.attackKey;
    }

    void Update()
    {
        if (CanPlayerAttack())
        {
            DoAttack();
        }
    }


    void DoAttack()
    {
        attackAction?.Invoke(playerStats.attackDamage); // Starts to listen to Stats script

        PlayerAttackAnimation();
        EnemyHurtAnimation();
    }

    void PlayerAttackAnimation()
    {
        weaponArm.GetComponent<Animator>().SetTrigger("Attack");
    }

    void EnemyHurtAnimation()
    {
        enemyBody.GetComponent<Animator>().SetTrigger("Hurt");

        StartEnemyPopupDamage();
    }

    void StartEnemyPopupDamage()
    {
        if (playerHitTextUI && playerHitParentUI)
        {
            GameObject hitUI = Instantiate(playerHitTextUI, playerHitParentUI.transform);
            hitUI.GetComponent<TMP_Text>().text = $"-{playerStats.attackDamage}";
            Destroy(hitUI, 1);
        }
    }

    //For readable booleans
    bool CanPlayerAttack() => (!isEnemyDead && Input.GetKeyDown(kc)) ? true : false;
}
