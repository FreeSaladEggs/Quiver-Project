using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3f;
    public float attackDistance = 2f;
    public float attackCooldown = 2f;
    public int damageAmount = 10;
    public Animator animator;

    private bool isAttacking = false;
    private float attackTimer = 0f;

    private void Update()
    {
        if (playerTransform != null)
        {
            Vector3 playerPosition = playerTransform.position;
            playerPosition.y = transform.position.y; // Set the same y-position as the enemy

            // Calculate the direction from the enemy to the player on the XZ plane
            Vector3 direction = playerPosition - transform.position;
            float distanceToPlayer = direction.magnitude;

            // Normalize the direction vector to get a unit vector on the XZ plane
            direction.Normalize();

            // Check if within attack range
            if (distanceToPlayer <= attackDistance)
            {
                if (!isAttacking)
                {
                    // Start attacking the player
                    AttackPlayer();
                }
            }
            else
            {
                // Move the enemy towards the player on the XZ plane
                transform.position += new Vector3(direction.x, 0f, direction.z) * moveSpeed * Time.deltaTime;
            }

            // Update attack cooldown timer
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
    }
}
