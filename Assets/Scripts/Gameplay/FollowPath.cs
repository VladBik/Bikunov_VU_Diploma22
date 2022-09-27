using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }


    public MovementType Type = MovementType.Moveing;
    public MovementPath MyPath;
    public float speed = 1;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    //public bool facingRight = false;
    //public Transform point_1;
    //public Transform point_2;
    Rigidbody2D rgb;
   


    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (MyPath == null)
        {
            Debug.Log("Примени Путь");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("Нужны точки");
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    
    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
            
        }

        if (Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
            
        }
        else if (Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSquere = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquere < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }

       

        
    }

    






}
