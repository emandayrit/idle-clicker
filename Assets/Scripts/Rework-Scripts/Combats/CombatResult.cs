using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatResult : MonoBehaviour
{
    public static CombatResult instance;
    public static float transitionSecond = 2f;
    public static double currency;
    public static double experience;
    public static double material;

    private static UnitHandler playerHandler;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        InializeHandlers();
    }

    //if player wins
    public static void PlayerVictory()
    {
        playerHandler.rewards.baseCurrency += currency;
        playerHandler.rewards.baseExperience += experience;
        playerHandler.rewards.baseMaterial += material;

        Debug.Log($"You win!");
        instance.StartCoroutine(SceneTransitionCoroutine());
    }

    //if player loses
    public static void PlayerDefeated()
    {
        playerHandler.rewards.baseCurrency += currency;
        playerHandler.rewards.baseExperience += experience;
        playerHandler.rewards.baseMaterial += material;

        Debug.Log($"You lose!");
        instance.StartCoroutine(SceneTransitionCoroutine());
    }

    public static void TransferReward(double c, double e, double m)
    {
        currency += c;
        experience += e;
        material += m;

        Debug.Log($"{currency} : {experience} : {material}");
    }

    public static IEnumerator SceneTransitionCoroutine()
    {
        yield return new WaitForSeconds(transitionSecond);

        SceneManager.LoadScene("GameScene");
    }

    private void InializeHandlers()
    {
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitHandler>();
    }
}
