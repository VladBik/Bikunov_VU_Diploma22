using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0F;
    public Rigidbody2D rb;
    public int damage = 1;
    [SerializeField]
    private AudioSource AudioS;
    public int scorerat = 0;
    public int scorebat = 0;

    public float seeDistance = 11f;

    public float attackDistance = 10f;
    private Transform target;

    void Start()
    {

        AudioS = GetComponent<AudioSource>();
        target = GameObject.FindWithTag("Enemy").transform;

    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > attackDistance)
        {
            transform.right = target.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);

        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime); 
        }
        Destroy(gameObject, 1.0F);

        //if (scorebat >= 10.0f)
      //  {
         //   speed = 11;
       // }


       // if (Time.fixedTime >= 54.0f)
      //  {
          //  speed = 12;
        //}

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("попадание по врагу чесноком");
            AudioS.Play();
            Destroy(gameObject, 0.1f);
        }
    }
}
