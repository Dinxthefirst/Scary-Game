using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    CoinSpawner coinSpawner;

    Player playerScript;

    private RaycastHit sightHitInfo;
    private RaycastHit attackHitInfo;

    public float walkSpeed = 3.5f;
    public float chaseSpeed = 7f;
    public Vector3 walkPoint;
    bool walkPointSet;
    bool chasePointSet;
    public Transform[] points;
    int destPoint = 0;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, playerDead;
    bool screamRecharged = true;

    AudioManager audioManager;
    Animator anim;

    private void Awake() 
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        anim = GameObject.Find("Monster New").GetComponent<Animator>();
        coinSpawner = FindObjectOfType<CoinSpawner>();
        playerScript = FindObjectOfType<Player>();
        audioManager.Play("Monster Footsteps");
    }

    private void Update()
    {
        RayCastToPlayer();

        if (playerScript.totalCoins == coinSpawner.coinAmount) ChasePlayer();
        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void RayCastToPlayer() 
    {
        Ray ray = new Ray(transform.position, player.position - transform.position);
        if (Physics.Raycast(ray, out sightHitInfo, sightRange) && sightHitInfo.collider.gameObject.name == "Player") 
        {
            Debug.DrawLine(transform.position, sightHitInfo.point, Color.green);
            playerInSightRange = true;

            if(sightHitInfo.distance < attackRange)
            {
                playerInAttackRange = true;
            }
        }
        else 
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * sightRange, Color.red);
            playerInSightRange = false;
        }
    }

    private void Patrolling()
    {
        agent.speed = walkSpeed;
        if (chasePointSet) GotoLastPlayerPosition();
        else if (!walkPointSet) GotoRandomPatrolPoint();
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            audioManager.StopPlaying("Monster Scream");
            anim.SetBool("isChasing", false);

            screamRecharged = true;
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f) 
        {
            chasePointSet = false;
            walkPointSet = false;
        }
    }
    private void GotoRandomPatrolPoint()
    {
        destPoint = Random.Range(0, points.Length);

        walkPoint = points[destPoint].position;

        walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        walkPoint = player.position;
        agent.SetDestination(walkPoint);
        chasePointSet = true;
        walkPointSet = false;
        if (screamRecharged)
        {
            audioManager.Play("Monster Scream");
            anim.SetBool("isChasing", true);
            screamRecharged = false;
        }
    }

    private void GotoLastPlayerPosition()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(walkPoint);
    }

    private void AttackPlayer()
    {
        if (!playerDead)
        {
            playerDead = true;
            audioManager.StopPlaying("Monster Footsteps");
            DeathMenu.PlayerDied();
        }
    }

}
