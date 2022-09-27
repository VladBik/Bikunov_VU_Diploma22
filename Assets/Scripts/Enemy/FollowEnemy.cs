using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    [SerializeField]
    private Behaviour _turnoffthis;
    Transform target;
    public float speed;

    public GameObject AudDeath;
    public GameObject Expl;

    public DropItem[] dropList;

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _turnoffthis.enabled = false;
        AudDeath.SetActive(false);
        Expl.SetActive(false);
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }

    public void CheckDrop()
    {
        if (dropList.Length > 0)
        {
            int rnd = (int)Random.Range(0, 100);

            foreach (var item in dropList)
            {
                if (item.chance < rnd)
                {
                    item.CreateDropItem(gameObject.transform.position);
                    Debug.Log("enemy dropped stuff");
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletGarlic")
        {
            Debug.Log("1 Bat was killed");
            AudDeath.SetActive(true);
            Expl.SetActive(true);
            Destroy(gameObject, 0.20f);
        }

    }

}
