using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public MenuManager menuManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        menuManager.onCollision();
    }
}
