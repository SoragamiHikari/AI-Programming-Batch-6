using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();
    public float chaseDistance;
    public Player player;

    private BaseState currentState;

    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();
    public RetreatState retreatState = new RetreatState();

    public NavMeshAgent navMeshAgent;
    [HideInInspector] public Animator animator;

    public void SwitchState(BaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    private void StartRetreat()
    {
        SwitchState(retreatState);
    }
    private void StopRetreat()
    {
       SwitchState(patrolState);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

        currentState = patrolState;
        currentState.EnterState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if(player != null)
        {
            player.OnPowerUpStart += StartRetreat;
            player.OnPowerUpEnd += StopRetreat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState !=  null)
        {
            currentState.UpdateState(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(currentState != retreatState)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Player>().Dead();
            }
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
