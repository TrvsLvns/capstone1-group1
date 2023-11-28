using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; // difference between current and next position
    private RaycastHit2D hit; // used for casting the collider box ahead to check if allowed in a location
    private int HP; //Health poinra

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        HP = 3; //Start player off with 3 HP
    }

    private void FixedUpdate()
    {
        
        float x = Input.GetAxisRaw("Horizontal"); // returns -1 if pressing A, 0 if nothing, 1 is pressing D
        float y = Input.GetAxisRaw("Vertical"); // same thing but with W and S

        // reset moveDelta
        moveDelta = Vector3.zero;

        moveDelta = new Vector3(x, y, 0);
        
        // Swap sprite direction if going right or left
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        } 
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }

        // Check if we can move in the y direction
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * 2 * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        if (hit.collider == null)
        {
            // Actually do the y movement
            transform.Translate(0, moveDelta.y * 2 * Time.deltaTime, 0); // Time.deltaTime smooths out performance between devices
        }

        // Check if we can move in the x direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * 2 * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Actually do the Xy movement
            transform.Translate(moveDelta.x * 2 * Time.deltaTime, 0, 0); // Time.deltaTime smooths out performance between devices
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Decrement HP when hit by enemy
            HP--;

            if (HP == 0)
            {
                // Destroy the object when HP hits 0
                Destroy(this.gameObject);
            }
            // Quit application or something.
        }
    }
}
