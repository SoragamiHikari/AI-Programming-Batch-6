using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public void EnterState(Enemy enemyParameter)
    {
        Debug.Log("start chase");
    }
    public void UpdateState(Enemy enemyParameter)
    {
        if(enemyParameter.player !=  null)
        {
            enemyParameter.navMeshAgent.destination = enemyParameter.player.transform.position;
            if(Vector3.Distance(enemyParameter.transform.position, enemyParameter.player.transform.position) > enemyParameter.chaseDistance)
            {
                enemyParameter.SwitchState(enemyParameter.patrolState);
            }
        }
    }
    public void ExitState(Enemy enemyParameter)
    {
        Debug.Log("stop chase");
    }
}
