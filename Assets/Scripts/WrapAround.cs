using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    public float screenEdgeX = 9f, screenEdgeY = 5.06f;
    public bool check;
    private void Update()
    {
        if (check)
        {
            wrap();
        }
        
    }
    public bool wrap()
    {
        if (transform.position.x > screenEdgeX)
        {
            transform.position = new Vector3(-screenEdgeX, transform.position.y, transform.position.z);
            return true;
        }
        if (transform.position.x < -screenEdgeX)
        {
            transform.position = new Vector3(screenEdgeX, transform.position.y, transform.position.z);
            return true;
        }
        if (transform.position.y > screenEdgeY)
        {
            transform.position = new Vector3(transform.position.x, -screenEdgeY, transform.position.z);
            return true;
        }
        if (transform.position.y < -screenEdgeY)
        {
            transform.position = new Vector3(transform.position.x, screenEdgeY, transform.position.z);
            return true;
        }
        return false;
    }
    
}
