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
    public bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    [HideInInspector]
    public bool isDead;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    private void Awake()
    {
        playerHead = GameManager.instance.PlayerHead;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0.5f);
        alreadyAttacked = false;
    }
    private void Update()
    {
        if (isDead) return;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

       if (playerInSightRange)
        {
            ChasePlayer();
        }

        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }
  
    private void ChasePlayer()
    {
        agent.SetDestination(playerHead.position);
        agent.isStopped = false;
        //Debug.Log(agent.destination);
    }

    private void AttackPlayer ()
    {


        if (!alreadyAttacked)
        {
            //Attack code
            animator.SetTrigger("Attack");
            animator.SetBool("AlreadyAttacked", true);
            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), attacksDelta);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("AlreadyAttacked", false);
        
    }

    public void TakeDamage(int dmg)
    {
        skeletonHealth -= dmg;
        if (skeletonHealth <= 0)
        {
            animator.SetBool("IsDead",true);
            Invoke(nameof(DestroySkeleton), 1f);
            isDead = true;

            if (OnEnemyKilled != null)
            {
                OnEnemyKilled();
            }
        }
    }

    private void DestroySkeleton()
    {
        Destroy(gameObject);
    }
}
