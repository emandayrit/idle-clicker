using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTransition : MonoBehaviour
{
    Animator _playerAnimator;
    PlayerMovement _playerMovement;


    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Stats _enemy = collision.gameObject.GetComponentInParent<Stats>();
        if (_enemy != null && _enemy.CompareTag("Enemy"))
        {
            //to stop player movement and walk animation
            _playerAnimator.SetFloat("Speed", 0);
            _playerMovement.enabled = false;

            StartCoroutine(CombatTransitionCoroutine(1.5f));
        }
    }

    IEnumerator CombatTransitionCoroutine(float _second)
    {
        Debug.Log("Get Ready to Combat!");
        yield return new WaitForSeconds(_second);
        //do scene transition here

        SceneManager.LoadScene(2); //0 = Main Menu, 1 = Game Scene, 2 = Combat Scene
    }

}
