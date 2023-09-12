using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyReward : MonoBehaviour
{
    private UnitHandler enemyHandler;
    private UnitHandler playerHandler;

    private double currency;
    private double experience;
    private double material;

    private void OnEnable()
    {
        InitializeHandlers();
    }

    public void GetRewards()
    {
        currency += enemyHandler.rewards.baseCurrency;
        experience += enemyHandler.rewards.baseExperience;
        material += enemyHandler.rewards.baseMaterial;
    }

    public double GiveCurrency()
    {
        return currency;
    }

    public double GiveExperience()
    {
        return experience;
    }

    public double GiveMaterial()
    {
        return material;
    }

    private void InitializeHandlers()
    {
        enemyHandler = GetComponent<UnitHandler>();
        playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitHandler>();
    }
}
