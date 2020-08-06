using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    private bool attackingActive = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public virtual void Attack()
    {
        if (attackingActive == true)
            return;

        attackingActive = true;
        StartCoroutine(AttackCoroutine());
    }

    public virtual void StopAttack()
    {
        attackingActive = false;
    }

    private IEnumerator AttackCoroutine()
    {
        animator.SetBool("Attack", true);

        while (attackingActive == true)
        {
            if (playerHealth)
            {
                playerHealth.DecreaseHealth(5);
            }

            yield return (new WaitForSeconds(2));
        }
    }
}