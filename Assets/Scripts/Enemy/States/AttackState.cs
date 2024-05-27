using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    public override void OnEnter()
    {
         
    }

    public override void OnExecute()
    {
        if (enemy.CanSeePlayer())
        {
            enemy.NavMeshAgent.SetDestination(enemy.target.transform.position);
        }
        else
        {
            stateMachine.ChangeState(new PatrolState());
        }
        if (enemy.health <= 0)
        {
            stateMachine.ChangeState(new DeadState());
        }
    }

    public override void OnExit()
    {

    }
}
