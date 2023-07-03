using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField] StatsValue stats;
    private GameObject _enemyBody;
    private string _enemyTag = "Enemy";

    private void Awake()
    {
        _enemyBody = transform.GetChild(0).gameObject;
        stats.InitializeEnemyHP();
    }

    private void OnEnable() => AttackClick.attackAction += EnemyDamage;

    private void OnDisable() => AttackClick.attackAction -= EnemyDamage;

    public void EnemyDamage(int _damage)
    {
        if(IsEnemy())
        {
            stats.currentHp -= _damage;

            if (IsDead())
            {
                float _switchSceneInSeconds = 1f;
                StartCoroutine(EnemyDefeatedCoroutine(_switchSceneInSeconds));
            }
        }
    }

    IEnumerator EnemyDefeatedCoroutine(float _transitionTimeInSeconds)
    {
        Debug.Log("Enemy Defeated!");
        _enemyBody.SetActive(false);

        yield return new WaitForSeconds(_transitionTimeInSeconds);
        SceneManager.LoadScene(1); //0 = Main Menu, 1 = Game Scene, 2 = Combat Scene
    }

    bool IsEnemy() => (gameObject.CompareTag(_enemyTag)) ? true : false;
    bool IsDead() => (stats.currentHp <= 0) ? true : false;
}
