using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCommonAtt1 : MonoBehaviour
{
    //[SerializeField]
    //private Behaviour _turnoffthis;
    
   public Animator _anim;
    public int scoreCommon; //сила удара по жизням игрока
    public CommonHeroGainCauldron1 colorCouldron;
   
    [SerializeField]
    private GameObject PlayAudioDeathG;

    public Animation anim; //скорость атаки анимацией
    //public float threshold;
    Transform target;
    //public Vector3 target;
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private int lives = 3;
    protected SpriteRenderer spriteRenderer;
    private Coroutine moveRoutine;
    private void Start()
    {
        speed = 1;
        target = GameObject.FindWithTag("EnemyWeak").GetComponent<Transform>();
        _anim = GetComponentInChildren<Animator>();
       // _turnoffthis.enabled = false;
        FindGameController();
        PlayAudioDeathG.SetActive(false);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim["AttackcommonHero"].speed = 0.5f;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        if (target == null)
            return;
        if (lives <= 0)
        {
            DeathCommonHero();
        }
        else
        {
            return;
        }
       
    }
    
    public void AddAttSpeed()
    {
        anim["AttackcommonHero"].speed += 1;
    }
       
    
    
    
    private void DeathCommonHero()
    {
        _anim.SetTrigger("Death");

        PlayAudioDeathG.SetActive(true);
        colorCouldron.DamagePlayerHP(scoreCommon);
        Debug.Log("Обычный герой повержен!");
       //Destroy(gameObject, 0.30f); // или отключить скрипт героя
    }
    private void FindGameController()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("ColorCauldron");
        if (GameControllerObject != null)
        {
            colorCouldron = GameControllerObject.GetComponent<CommonHeroGainCauldron1>();
        }
        if (GameControllerObject == null)
        {
            Debug.Log("скрипт не найден");
        }
    }
    

    private void TakeDamageCommon()
    {
        lives -= 1;
        //_anim.SetBool("InCombat", true);
        if (lives < 0)
        {
            lives = 0;
        }
    }
    private void TakeRangeDamageCommon()
    {
        lives -= 2;

        if (lives < 0)
        {
            lives = 0;
        }
    }
    public void Damage(int damageAmount)
    {
        _anim.SetTrigger("Hit");

        lives -= damageAmount;

        Debug.Log(gameObject.name + " Took a damage of:" + damageAmount);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _anim.SetTrigger("Hit");
            speed = 0;
            Debug.Log("Вошел в боевое столкновение с врагом!");

        }
        else
        {
            target = GameObject.FindWithTag("EnemyWeak").GetComponent<Transform>();
            _anim.SetTrigger("Moving");
            speed = 1;
            
        }
        if (collision.tag == "EnemySword")
        {
            Damage(1);
            colorCouldron.DamagePlayerHP(scoreCommon);
            Debug.Log("Игрок получил урон:");
            if (lives <= 0)
            {
                lives = 0;
                Destroy(gameObject, 0.40f);

                Debug.Log(gameObject.name + " is dead ");

            }

        }

    }
   
   
    private void OnTriggerEnter(Collider collision)
    {
        
       
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("Попали дистанционной атакой!");
            TakeRangeDamageCommon();

        }

    }
}
