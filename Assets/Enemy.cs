using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float moveSpeed = 2.0f;  // Speed at which the enemy moves towards the player

    public Animator animator;

    private RaycastHit2D hit; // used for casting the collider box ahead to check if allowed in a location

    private BoxCollider2D boxCollider;

    private void Start()
    {
        // Find the player GameObject in the scene if not set
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Normalize the direction to get a unit vector
            directionToPlayer.Normalize();

            // Move the enemy towards the player
            transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);

            // HandleAnimation(directionToPlayer);
        }

    }

    // private void HandleAnimation(Vector3 direction);
    // {
    //     if (Math.Abs(direction.y) > Math.Abs(direction.x))
    //     {
    //         if (direction.y > 0)
    //         {
    //             animator.Play("enemyWalkUp");
    //         }
    //         else
    //         {
    //             animator.Play("enemyWalkDown");
    //         }
            
    //     }
    //     else if (Math.Abs(direction.x) > Math.Abs(direction.y))
    //     {
    //         if (direction.x > 0)
    //         {
    //             animator.Play("enemyWalkLeft");
    //         }
    //         else
    //         {
    //             animator.Play("enemyWalkRight");
    //         }
    //     }
    //     else
    //     {
    //         animator.Play("Idle");
    //     }
    // }
}
