using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Transform playerHead;
    public int skeletonHealth = 100;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float attacksDelta;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        playerHead = GameManager.instance.PlayerHead;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }


    private void ChasePlayer()
    {
        agent.SetDestination(playerHead.position);
    }

    private void AttackPlayer ()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(playerHead);

        if (!alreadyAttacked)
        {
            //Attack code
            animator.Play("Strike_1");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attacksDelta);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;

        if (skeletonHealth <= 0)
        {
            animator.Play("Death_1");
            Invoke(nameof(DestroySkeleton), 1f);
        }
    }

    public void TakeDamage(int dmg)
    {
        skeletonHealth -= dmg;
    }

    private void DestroySkeleton()
    {
        Destroy(gameObject);
    }
}
