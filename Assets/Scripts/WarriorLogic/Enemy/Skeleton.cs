using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour //Enemy,IDamageable
{

    private Vector3 target;
    [SerializeField]
    protected int Health = 6;

    [SerializeField]
     private HealthBar _healthBar;
    
    [SerializeField]
    protected int maxHealth = 6;

    //Тест дропа
    [SerializeField]
    private GameObject item1;
    [SerializeField]
    private float _dropchanse = 30;
    float rnd;

    //public DropItem[] dropList;

    //Конец теста дропа
   
    [SerializeField]
    protected float moveSpeed = 1.0f;
    [SerializeField]
    protected int gems = 10;
    [SerializeField]
    protected Transform pointA, pointB;
    protected Animator _anim;
    protected SpriteRenderer spriteRenderer;
    protected bool reverse = false;
    protected bool isHit = false;
    Transform Player;
    [SerializeField]
    private GameObject SkeletCollider;
    public AudioSource audioSource;
    //public AudioSource audioSourceWalk;
    //public int Health = 6; //{ get; set; }
    
    //protected virtual void Attack();
   private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        target = pointB.position;
        Debug.Log(spriteRenderer.name);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        //audioSourceWalk = GetComponent<AudioSource>();
        Health = maxHealth;
        maxHealth = 6;
        _healthBar.SetHealthValue(Health, maxHealth);
        SkeletCollider.SetActive(true);
        _dropchanse = 30;
        moveSpeed = 1.0f;
    }
    private void Update()
    {
        isHit = _anim.GetBool("InCombat");
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && _anim.GetBool("InCombat") == false) return;
        Walk();

        if (_anim.GetBool("InCombat") == true)
        {
            float direction = Player.localPosition.x - transform.localPosition.x;
            if (direction < 0) { spriteRenderer.flipX = true; }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        
        
    }
    public void Damage(int damageAmount)
    {
        _anim.SetTrigger("Hit");
        _anim.SetBool("InCombat", true);
        Health -= damageAmount;
        _healthBar.SetHealthValue(Health, maxHealth);
        Debug.Log(gameObject.name + " Took a damage of:" + damageAmount);
        isHit = true;
        if (Health <= 0)
        {
            Health = 0;
            SkeletCollider.SetActive(false);
            _anim.SetTrigger("Death");
            DropItem();
            Debug.Log(gameObject.name + " is dead ");
            Destroy(gameObject, 0.46f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            Damage(2);
            audioSource.Play();
            _anim.SetTrigger("Hit");
            Debug.Log("Получен 2 урона от меча");

        }
    }

    public void DropItem()
    {
        //if (dropList.Length > 0)
       // {
           // int rnd = (int)UnityEngine.Random.Range(0, 100);

            //foreach (var item in dropList)
           // {
               // if (item.chance <= rnd)
               // {
                   // item.CreateDropItem(gameObject.transform.position);
                   // return;
               // }
           // }
        //}

         rnd = UnityEngine.Random.Range(0, 100);
        if (rnd <= _dropchanse)
         {
        GameObject Item = Instantiate(item1, transform.position, Quaternion.identity);
            Debug.Log(" Выпало из врага");

        }
        else
         {
            Debug.Log("Ничего не выпало");
            Destroy(gameObject, 0.46f);
         }
    }
    private void Walk()
    {
        spriteRenderer.flipX = reverse;
        if (transform.position == pointA.position)
        {
            _anim.SetTrigger("Idle");
            reverse = false;
            target = pointB.position;
            //audioSourceWalk.Play();

        }
        if (transform.position == pointB.position)
        {
            _anim.SetTrigger("Idle");
            reverse = true;
            target = pointA.position;
            //audioSourceWalk.Play();
        }
        var speed = moveSpeed * Time.deltaTime;
        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
        if (isHit)
        {
            _anim.SetBool("InCombat", true);
            Debug.Log(Vector2.Distance(Player.position, transform.position));
            if (Vector2.Distance(Player.position, transform.position) > 2)
            {
                _anim.SetBool("InCombat", false);
                isHit = false;
            }
        }

        








            // protected override void Attack()
            // {

            // }

            // Start is called before the first frame update
            // protected override void  Start()
            // {
            //health = 10;
            //  moveSpeed = 1.0f;
            // gems = 2;
            // Health = health;
            // base.Start();
            // }
            // protected override void Update()
            //  {

            //  base.Update();


            // }
            // Update is called once per frame

        }
}