using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseState
{
    public void EnterState(Enemy enemyParameter);
    public void UpdateState(Enemy enemyParameter);
    public void ExitState(Enemy enemyParameter);
}
