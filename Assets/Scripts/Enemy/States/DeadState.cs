using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState
{
    public override void OnEnter()
    {
        enemy.ChangeAnim(Enemy.EnemyState.Dead);
        enemy.GetComponent<BoxCollider>().enabled = false;
        enemy.NavMeshAgent.SetDestination(enemy.transform.position);
    }

    public override void OnExecute()
    {
        enemy.OnDeath();
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }
}
