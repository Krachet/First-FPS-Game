using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : EnemyHealth
{
    public StateMachine stateMachine;
    private NavMeshAgent navMeshAgent;

    public GameObject target;
    private GameObject player;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    public NavMeshAgent NavMeshAgent { get => navMeshAgent; }

    [SerializeField] private string currentState;
    public Path path;

    public Animator anim;

    public enum EnemyState
    {
        Patrol,
        Dead
    }

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
        stateMachine = GetComponent<StateMachine>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine.OnInit();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
    }

    public bool CanSeePlayer()
    {
        if (player)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(ray, out hit, sightDistance))
                    {
                        if (hit.collider.gameObject.tag == "Player")
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.red);
                            target = hit.collider.gameObject;
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Heal(float heal)
    {
        base.Heal(heal);
    }

    public void ChangeAnim(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.Patrol:
                anim.SetBool("Patrol", true);
                anim.SetBool("Dead", false);
                break;
            case EnemyState.Dead:
                anim.SetBool("Patrol", false);
                anim.SetBool("Dead", true);
                break;
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject, 2f);
    }
}
