using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator animator;
    private Transform playerHead;
    public int skeletonHealth = 100;
    public LayerMask whatIsPlayer;

    //Walking
    public Vector3 walkPoint;
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

        ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }
  
    private void ChasePlayer()
    {
        agent.SetDestination(playerHead.position);
        animator.SetFloat("Speed",0.5f);
        //Debug.Log(agent.destination);
    }

    private void AttackPlayer ()
    {
        agent.SetDestination(playerHead.position);

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
