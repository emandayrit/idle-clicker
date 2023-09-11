using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase {START,TURN,WIN,LOSE}

public class CombatPhase : MonoBehaviour
{
    public Phase phase;

    private void Start()
    {
        phase = Phase.START;
        CombatStart();
    }

    private void CombatStart()
    {

    }

    private void CombatTurn()
    {

    }

    private void CombatWin()
    {

    }

    private void CombatLose()
    {

    }
}
