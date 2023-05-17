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
    public Animator animator;

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
                    AttackPlayer();
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
    public void AttackPlayer()
    {
        Debug.Log("enemy yadhrab");
        animator.SetTrigger("isAttacking");
        //-HP Player
    }
}
