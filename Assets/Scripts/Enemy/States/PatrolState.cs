using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;

    public float waitTime;
    public override void OnEnter()
    {
        enemy.ChangeAnim(Enemy.EnemyState.Patrol);
    }

    public override void OnExecute()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
        if (enemy.health <= 0)
        {
            stateMachine.ChangeState(new DeadState());
        }
    }

    public override void OnExit()
    {

    }

    public void PatrolCycle()
    {
        if (enemy.NavMeshAgent.remainingDistance < 0.5f)
        {
            waitTime += Time.deltaTime;
            if (waitTime > 0.2f)
            {
                waypointIndex = Random.Range(0, enemy.path.waypoints.Count);
                enemy.NavMeshAgent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                enemy.transform.LookAt(enemy.path.waypoints[waypointIndex].position);
                waitTime = 0;
            }
        }
    }
}
