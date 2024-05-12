using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    private bool _isMoving;
    private Vector3 _destination;

    public void EnterState(Enemy enemyParameter)
    {
        _isMoving = false;
        enemyParameter.animator.SetTrigger("PatrolState");
    }
    public void UpdateState(Enemy enemyParameter)
    {
        if(Vector3.Distance(enemyParameter.transform.position, enemyParameter.player.transform.position) < enemyParameter.chaseDistance)
        {
            enemyParameter.SwitchState(enemyParameter.chaseState);
        }

        if(!_isMoving)
        {
            int index = UnityEngine.Random.Range(0, enemyParameter.wayPoints.Count);
            _destination = enemyParameter.wayPoints[index].position;
            enemyParameter.navMeshAgent.destination = _destination;
            _isMoving = true;
        }
        else
        {
            if(Vector3.Distance(_destination, enemyParameter.transform.position) <= 0.1)
            {
                _isMoving=false;
            }
        }
    }
    public void ExitState(Enemy enemyParameter)
    {
        Debug.Log("stop patrol");
    }
}
