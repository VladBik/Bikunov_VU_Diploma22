using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove1 : MonoBehaviour
{
    [SerializeField]
    protected Transform pointA, pointB;
    [SerializeField]
    protected float moveSpeed = 1.0f;
    private Vector3 target;

    protected virtual void Start()
    {
        
        target = pointB.position;
        
       
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards (transform.position, target, moveSpeed * Time.fixedDeltaTime);
        Walk();
    }
    protected virtual void Walk()
    {
        
        if (transform.position == pointA.position)
        {
            
          
            target = pointB.position;
        }
        if (transform.position == pointB.position)
        {
            
            target = pointA.position;
        }
        var speed = moveSpeed * Time.deltaTime;
       
       


    }
}
