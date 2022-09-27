using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    [SerializeField]
    private Behaviour _following;

    public float seeDistance = 11f;
    public float attackDistance = 10f;
    public float speed = 0.1F;

    private Transform target;

    public GameObject AudDFly;

    public GameObject Expl;

    void Start()
    {


        target = GameObject.FindWithTag("Player").transform;

    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > attackDistance)
        {
            //transform.right = target.transform.position - transform.position;
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            speed -= 0;
        }

        else
        {
            Debug.Log("Враг движется к игроку");
            AudDFly.SetActive(true);
            _following.enabled = true;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "BulletGarlic")
        {
            Expl.SetActive(true);
            Destroy(gameObject, 0.20f);
            Debug.Log("Враг погиб от пули");


        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.1f);
            Debug.Log("Враг столкнулся с игроком");

        }
    }
}