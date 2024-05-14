using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent navMeshAgent;

    public NavMeshAgent NavMeshAgent { get => navMeshAgent; }

    [SerializeField] private string currentState;
    public Path path;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine.OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
