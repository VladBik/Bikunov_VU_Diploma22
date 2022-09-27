using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public Animator _anim;
    public int scoreCommon; //сила удара по жизням игрока
    public CommonHeroGainCauldron3 colorCouldron;
    public int deathCount; //учет смертей
    [SerializeField]
    private GameObject PlayAudioDeathG;
    [SerializeField]
    private GameObject EnemyColl1;

    public Animation anim; //скорость атаки анимацией
    //public float threshold;
    public Transform targetPl;
    //public Vector3 target;
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private int livesEnem = 3;
    protected SpriteRenderer spriteRenderer;
    private Coroutine moveRoutine;
    private void Start()
    {

        EnemyColl1.SetActive(true);
        targetPl = GameObject.FindWithTag("HeroWeak").GetComponent<Transform>();
        _anim = GetComponentInChildren<Animator>();
        // _turnoffthis.enabled = false;
        FindGameController();
        PlayAudioDeathG.SetActive(false);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }


    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPl.position, speed * Time.fixedDeltaTime);
        if (livesEnem <= 0)
        {
            livesEnem = 0;
            DeathCounting();
            DeathCommonEnemy();
        }


    }

    public void Damage(int damageAmount)
    {
        _anim.SetTrigger("Hit");

        livesEnem -= damageAmount;

        Debug.Log(gameObject.name + " Took a damage of:" + damageAmount);


    }
    public void AddAttSpeedSlime()
    {

    }

    private void DeathCommonEnemy()
    {
        EnemyColl1.SetActive(false);
        _anim.SetTrigger("Death");

        PlayAudioDeathG.SetActive(true);

        colorCouldron.DamageEnemyHP(scoreCommon);
        Debug.Log("Враг повержен!");
        speed = 0;
        Destroy(gameObject); // или отключить скрипт героя
        if (livesEnem <= 0)
        {
            livesEnem = 0;

        }
    }
    private void DeathCounting()
    {
        colorCouldron.DeathCount(deathCount);
        Debug.Log("Одна смерть");

    }
    private void FindGameController()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("ColorCauldron");
        if (GameControllerObject != null)
        {
            colorCouldron = GameControllerObject.GetComponent<CommonHeroGainCauldron3>();
        }
        if (GameControllerObject == null)
        {
            Debug.Log("скрипт не найден");
        }
    }


    //private void TakeDamageCommon()
    // {
    // livesEnem -= 1;
    //_anim.SetBool("InCombat", true);
    // if (livesEnem < 0)
    // {
    //livesEnem = 0;
    //}
    // }
    private void TakeRangeDamageCommon()
    {
        livesEnem -= 2;

        if (livesEnem < 0)
        {
            livesEnem = 0;
            Destroy(gameObject, 0.30f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _anim.SetTrigger("Hit");
            //speed = 0;
            Debug.Log("Вошел в боевое столкновение с врагом!");

        }
        if (collision.gameObject.tag == "Sword")
        {
            Damage(1);
            colorCouldron.DamageEnemyHP(scoreCommon);
            if (livesEnem <= 0)
            {
                livesEnem = 0; ///new
                DeathCounting();
                livesEnem = 0;
                Destroy(gameObject, 0.30f);

                Debug.Log(gameObject.name + " is dead ");

            }

        }
        if (collision.gameObject.tag == "RareSword")
        {
            Damage(3);
            colorCouldron.DamageEnemyHP(scoreCommon);
            if (livesEnem <= 0)
            {
                livesEnem = 0;
                Destroy(gameObject, 0.30f);

                Debug.Log(gameObject.name + " is dead ");

            }

        }
    }
}
