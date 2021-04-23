using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_SCRIPT : MonoBehaviour
{
    public NavMeshAgent enemyNav;
    public Transform Player;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public LayerMask whatIsGround, whatIsPlayer;
    //////////////////////
    // Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    ///////////////////////
    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    // SUB - shooting stuff
    public GameObject bullet;
    public Transform shootLoc;
    ///////////////////////
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
        enemyNav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        else if (playerInSightRange && !playerInAttackRange) Chase();
        else if (playerInAttackRange) Attack();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SetWalkPoint();

        if (walkPointSet) enemyNav.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;

    }

    private void SetWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); // That's alotta code!
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }


    }
    private void Chase()
    {
        enemyNav.SetDestination(Player.position);
    }

    private void Attack()
    {
        enemyNav.SetDestination(transform.position);
        transform.LookAt(Player);

        if (!alreadyAttacked) {
            // THIS IS WHERE YOU DO ATTACK STUFF
            Instantiate(bullet, shootLoc.position, shootLoc.rotation);
            alreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttacks);

        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}