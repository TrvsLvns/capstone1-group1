using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // public allows changing it in the editor
    public Transform lookAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Use LateUpdate so this is called after movement is done
    void LateUpdate()
    {
        Vector3 delta; // difference on camera position between this frame and next frame
        delta.x = 0;
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX != 0)
        {
            delta.x = deltaX; 
        }

        float deltaY = lookAt.position.y - transform.position.y;
        delta.y = 0;
        if (deltaY != 0)
        {
            delta.y = deltaY;
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
