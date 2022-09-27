using System.Collections;

using System.Collections.Generic;
using UnityEngine;


public class Spider : MonoBehaviour //Enemy
{
    private Vector3 target;
    [SerializeField]
    protected int Health = 4;

    [SerializeField]
    private HealthBar _healthBar;
    [SerializeField]
    protected int maxHealth = 4;

    //Тест дропа
    [SerializeField]
    private GameObject item1;
    [SerializeField]
    private float _dropchanse = 100;
    float rnd;

    //public DropItem[] dropList;

    //Конец теста дропа

    [SerializeField]
    protected float moveSpeed = 2.5f;
    [SerializeField]
    protected int gems = 15;
    [SerializeField]
    protected Transform pointA, pointB;
    protected Animator _anim;
    protected SpriteRenderer spriteRenderer;
    protected bool reverse = false;
    protected bool isHit = false;
    Transform Player;
    [SerializeField]
    private GameObject SpiderCollider;
    public AudioSource audioSource;

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
            SpiderCollider.SetActive(false);
            _anim.SetTrigger("Death");
            Debug.Log(gameObject.name + " is dead ");
            Destroy(gameObject, 0.31f);
        }
    }
    private void Start()
    {
        
        _anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        target = pointB.position;
        Debug.Log(spriteRenderer.name);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        Health = maxHealth;
        maxHealth = 4;
        _healthBar.SetHealthValue(Health, maxHealth);
        SpiderCollider.SetActive(true);
        moveSpeed = 2.0f;
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
            Debug.Log("Получено: 2 урона от меча");

        }
    }

    public void DropItem()
    {
        
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