using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour

{
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform Gun;
    Vector2 direction;
    public Transform ShootPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mPos - (Vector2)Gun.position;
        FaceMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
        if (Input.GetMouseButtonDown(1))
        {

        }
    }
    void FaceMouse()

    {
        Gun.transform.right = direction;
    }
    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        Destroy(BulletIns, 2);
    }
    //    private void OnCollisionEnter(Collision collision)
    //    {
    //        if (collision.gameObject.CompareTag("Enemy")) 
    //        {
    //            // Destroy the collided object
    //            Destroy(collision.gameObject);

    //            // Destroy the bullet itself
    //            Destroy(gameObject);
    //        }
    //    }

}
