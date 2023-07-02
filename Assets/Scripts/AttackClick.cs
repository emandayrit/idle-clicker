using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClick : MonoBehaviour
{
    [SerializeField] KeyCode attackInput = KeyCode.Mouse0;

    [SerializeField] GameObject weaponArm;
    [SerializeField] GameObject enemyBody;

    [Header ("UI Objects")]
    [SerializeField] GameObject playerHitUI;

    void Update()
    {
        ClickAttack();
    }

    void ClickAttack()
    {
        if (Input.GetKeyDown(attackInput))
        {
            Debug.Log($"you clicked!");
            weaponArm.GetComponent<Animator>().SetTrigger("Attack");
            enemyBody.GetComponent<Animator>().SetTrigger("Hurt");

            //GameObject hitUI = Instantiate(playerHitUI, transform.position, Quaternion.identity);
            playerHitUI.SetActive(true);
            StartCoroutine(FadeDelay());
            //Destroy(hitUI, 1);
        }
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(0.2f);
        playerHitUI.SetActive(false);
    }
}
