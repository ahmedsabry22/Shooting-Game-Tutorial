using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float maxSpeed = 5;
    public float currentSpeed;
    public float stoppingDistance = 5;

    private PlayerMovement player;
    private Animator animator;
    private NavMeshAgent agent;
    private EnemyAttacking enemyAttacking;
    private bool startMove = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();

        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyAttacking = GetComponent<EnemyAttacking>();
    }

    private IEnumerator Start()
    {
        yield return (new WaitForSeconds(3));
        startMove = true;
    }

    private void Update()
    {
        if (!startMove)
            return;

        if (player)
            Move();
    }

    public virtual void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= stoppingDistance)
        {
            agent.SetDestination(player.transform.position);
            animator.SetFloat("Move", currentSpeed / maxSpeed);

            currentSpeed += Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, 5);

            animator.SetBool("Attack", false);
            enemyAttacking.StopAttack();
        }
        else
        {
            agent.SetDestination(transform.position);
            currentSpeed = 0;
            animator.SetFloat("Move", 0);

            enemyAttacking.Attack();

            Vector3 enemyToPlayer = player.transform.position - transform.position;
            enemyToPlayer.y = 0;

            transform.rotation = Quaternion.LookRotation(enemyToPlayer);
        }
    }
}