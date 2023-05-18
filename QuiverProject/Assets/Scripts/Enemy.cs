using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float attackDistance = 2f;
    public float attackCooldown = 2f;
    public int damageAmount = 10;
    public float attackRange = 2f;
    public Transform weaponAttackPoint;
    public Animator animator;
    public float gizmosSize = 0.5f;

    private bool isAttacking = false;
    private float attackTimer = 0f;

    private void Update()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.position;
            playerPosition.y = transform.position.y;


            Vector3 direction = playerPosition - transform.position;
            float distanceToPlayer = direction.magnitude;


            direction.Normalize();


            if (distanceToPlayer <= attackDistance)
            {
                if (!isAttacking)
                {
                    StartCoroutine(AttackPlayer());
                }
            }
            else
            {

                transform.position += new Vector3(direction.x, 0f, direction.z) * moveSpeed * Time.deltaTime;
            }

            if (isAttacking)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackCooldown)
                {
                    isAttacking = false;
                    attackTimer = 0f;
                }
            }
        }
    }
    private IEnumerator AttackPlayer()
    {
        Debug.Log("enemy yadhrab");
        isAttacking = true;
        animator.SetTrigger("isAttacking");

        yield return new WaitForSeconds(2f);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
       
        foreach (Collider collider in hitColliders)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
            //-HP Player
        }
    private void OnDrawGizmosSelected()
    {
        if (weaponAttackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(weaponAttackPoint.position, gizmosSize * attackRange);
        }
    }
}
