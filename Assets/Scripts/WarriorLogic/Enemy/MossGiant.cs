using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : MonoBehaviour
{

    private Vector3 target;
    [SerializeField]
    private HealthBar _healthBar;
    [SerializeField]
    protected int Health = 20;
    [SerializeField]
    protected int maxHealth = 20;
    [SerializeField]
    protected float moveSpeed = 4.0f;
    [SerializeField]
    protected int gems = 100;
    [SerializeField]
    protected Transform pointA, pointB;
    protected Animator _anim;
    protected SpriteRenderer spriteRenderer;
    protected bool reverse = false;
    protected bool isHit = false;
    Transform Player;
    
    //Тест дропа
    [SerializeField]
    private GameObject item1;
    [SerializeField]
    private float _dropchanse = 100;
    float rnd;

    //public DropItem[] dropList;

    //Конец теста дропа

   // public GameObject SphereRare;

    public AudioSource audioSource;
    [SerializeField]
    private GameObject GiantCollider;
    //public int Health = 6; //{ get; set; }
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
            _anim.SetTrigger("Death");
            GiantCollider.SetActive(false);
            Debug.Log(gameObject.name + " is dead ");
            DropItem();
            //SphereRare.SetActive(true);
            Destroy(gameObject, 0.45f);
        }
    }
    //protected virtual void Attack();
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        target = pointB.position;
        Debug.Log(spriteRenderer.name);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        Health = maxHealth;
        moveSpeed = 4.0f;
        gems = 100;
        maxHealth = 20;
        _healthBar.SetHealthValue(Health, maxHealth);
        _dropchanse = 100;
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            Damage(2);
            audioSource.Play();
            _anim.SetTrigger("Hit");
            Debug.Log("Получено 2 урона от меча");

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
        }
        if (transform.position == pointB.position)
        {
            _anim.SetTrigger("Idle");
            reverse = true;
            target = pointA.position;
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



    }
}