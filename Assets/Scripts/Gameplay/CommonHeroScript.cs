using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHeroScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    Transform target;
    [SerializeField]
    private float seeDistance = 12f;
    [SerializeField]
    public float attackDistance = 3f;
    [SerializeField]
    private GameObject Shooting3;
   [SerializeField]
   private int lives = 3;
    [SerializeField]
    private GameObject PlayAudioDeathG;
    protected Animator _anim;

    

    protected bool reverse = false;
    protected bool isHit = false;
    Transform EnemyWeak;
    Transform Enemy;
    [SerializeField]
    private GameObject CommonHeroCollider;
    protected SpriteRenderer spriteRenderer;

    [SerializeField]
    private Behaviour _following;

    public int scoreCommon; //сила удара по жизням игрока
    public CommonHeroGainCauldron1 colorCouldron;


    //[SerializeField]
    //private GameObject GreenExploisonPrefab;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        FindGameController();
        PlayAudioDeathG.SetActive(false);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        target = GameObject.FindWithTag("EnemyWeak").GetComponent<Transform>();
        _following.enabled = false;

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


    void FixedUpdate()
    {
        target = GameObject.FindWithTag("EnemyWeak").GetComponent<Transform>();
       
        TargetEnemyMove();


        if (Vector2.Distance(transform.position, target.transform.position) <= attackDistance)
        {
            Debug.Log("Нападаю!");
            speed -= 0;
            _anim.SetBool("InCombat", true);
            _following.enabled = true;

        }

        
        if (lives <= 0)
        {
            DeathCommonHero();
        }
        else
        {
            return;
        }
    }
   

    private void TargetEnemyMove()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        _anim.SetTrigger("Moving");

    }

    private void DeathCommonHero()
    {
        PlayAudioDeathG.SetActive(true);

        colorCouldron.DamagePlayerHP(scoreCommon);
        Debug.Log("Обычный герой повержен!");
        Destroy(gameObject, 0.30f); // или отключить скрипт героя
    }

    public void AddSpeed()
    {
        speed +=1;
    }

    public void LowSpeed()
    {
        speed -=1;
    }

    public void AddHP()
    {
        lives +=1;
    }

    public void LowHP()
    {
        lives -=1;
    }

    public void LaserAct()
    {
        
    }

    public void LaserDisact()
    {
        
    }

    private void TakeDamageCommon()
    {
        lives -=1;

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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("Вошел в боевое столкновение с врагом!");
            _anim.SetBool("InCombat", true);
        }
        else
        {
            _anim.SetBool("InCombat", false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "EnemySword")
        {
            TakeDamageCommon();

        }
        else if (collision.tag == null)
        {
            return;
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("Попали дистанционной атакой!");
            TakeRangeDamageCommon();

        }

    }
}
