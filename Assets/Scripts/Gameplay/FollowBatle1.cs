using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBatle1 : MonoBehaviour
{
    [SerializeField]
    private Behaviour _turnoffthis;
    Transform target;
    public float speed;
    [SerializeField]
    protected int Health = 6;

    [SerializeField]
    private HealthBar33 _healthBar;

    [SerializeField]
    protected int maxHealth = 6;

    public GameObject AudDeath;
    protected Animator _anim;
    public DropItem[] dropList;

    //_anim.SetTrigger("Hit");
    // _anim.SetBool("InCombat", true);  _anim.SetTrigger("Death");

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
        _turnoffthis.enabled = false;
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
            Destroy(gameObject, 0.3f);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            _anim.SetBool("InCombat", true);
            _anim.SetTrigger("Hit");
            }

    }
}
