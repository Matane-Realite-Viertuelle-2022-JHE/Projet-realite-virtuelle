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
    public GameObject damageText;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0.5f);
        alreadyAttacked = false;
    }
    private void Update()
    {
        playerHead = GameManager.instance.PlayerHead;
        Debug.Log(playerHead.position);
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
            animator.SetFloat("Random", Random.value);
            animator.SetTrigger("Attack");

            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), attacksDelta);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int dmg)
    {
        skeletonHealth -= dmg;
        DmgPop dmgPop = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DmgPop>();
        dmgPop.SetDamageText(dmg);
        if (skeletonHealth <= 0)
        {
            animator.SetBool("IsDead",true);
            animator.Play("Dead_1");
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
