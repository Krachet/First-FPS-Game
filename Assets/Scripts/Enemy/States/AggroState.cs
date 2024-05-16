using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroState : BaseState
{
    public override void OnEnter()
    {

    }

    public override void OnExecute()
    {
        enemy.NavMeshAgent.SetDestination(enemy.target.transform.position);
    }

    public override void OnExit()
    {

    }
}
