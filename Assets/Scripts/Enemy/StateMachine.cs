using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    public PatrolState patrolState;
    public AggroState aggroState;
    public AttackState attackState;
    
    public void OnInit()
    {
        aggroState = new AggroState();
        attackState = new AttackState();
        patrolState = new PatrolState();
        ChangeState(patrolState);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.OnExecute();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (activeState != null)
        {
            activeState.OnExit();
        }
        activeState = newState;
        
        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();  
            activeState.OnEnter();
        }
        Debug.Log(activeState.GetType().Name);
    }
}
