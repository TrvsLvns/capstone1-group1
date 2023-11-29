using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;

    private Vector2 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 direction = currentPosition - previousPosition;
        if (direction.x > 0)
        {
            transform.localScale = Vector3.one * 3;
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0) * 3;
        }
        previousPosition = currentPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Decrement HP by X when shot
            health -= 2;

            if (health == 0)
            {
                // Destroy the object when HP hits 0
                Destroy(this.gameObject);
            }
        }
    }
}
