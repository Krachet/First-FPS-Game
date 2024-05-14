using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public Enemy enemy;
    public StateMachine stateMachine;
    public abstract void OnEnter();
    public abstract void OnExecute();
    public abstract void OnExit();

}
