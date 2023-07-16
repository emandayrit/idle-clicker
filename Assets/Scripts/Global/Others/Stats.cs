using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public bool enemyDead;

    [SerializeField] StatsSO stats;
    [SerializeField] Animator enemyDeathAnimation;
    [SerializeField] GameObject victoryUI;
    private string _enemyTag = "Enemy";

    private void Awake()
    {
        enemyDead = false;
    }

    private void OnEnable() => PlayerAttack.attackAction += EnemyDamage;

    private void OnDisable() => PlayerAttack.attackAction -= EnemyDamage;

    public void EnemyDamage(int _damage)
    {
        if(IsTargetAnEnemy())
        {
            stats.currentHp -= _damage;

            if (IsEnemyDead())
            {
                float _exitCombatSceneInSeconds = 3f;
                StartCoroutine(EnemyDefeatedCoroutine(_exitCombatSceneInSeconds));
            }
        }
    }

    IEnumerator EnemyDefeatedCoroutine(float _seconds)
    {
        // Do Death animation
        FindAnyObjectByType<PlayerAttack>().isEnemyDead = true; //to stop doing attack
        enemyDeathAnimation.SetTrigger("Death");
        victoryUI.SetActive(true);
        yield return new WaitForSeconds(_seconds);

        SceneManager.LoadScene(1); //0 = Main Menu, 1 = Game Scene, 2 = Combat Scene
    }

    //For readable booleans
    private bool IsTargetAnEnemy() => (gameObject.CompareTag(_enemyTag)) ? true : false;
    private bool IsEnemyDead() => (stats.currentHp <= 0) ? true : false;
}
