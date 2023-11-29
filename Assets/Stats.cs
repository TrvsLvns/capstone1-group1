using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("WHATEVER TAG YOU NEED"))
        {
            //Decrement HP by X when shot
            health -= 5;

            if (health == 0)
            {
                // Destroy the object when HP hits 0
                Destroy(this.gameObject);
            }
        }
    }
}
