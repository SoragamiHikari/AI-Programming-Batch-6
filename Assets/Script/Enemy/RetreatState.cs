using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    public void EnterState(Enemy enemyParameter)
    {
        Debug.Log("start retreat");
    }
    public void UpdateState(Enemy enemyParameter)
    {
        if(enemyParameter != null)
        {
            enemyParameter.navMeshAgent.destination = enemyParameter.transform.position - enemyParameter.player.transform.position;
        }
    }
    public void ExitState(Enemy enemyParameter)
    {
        Debug.Log("stop retreat");
    }
}
