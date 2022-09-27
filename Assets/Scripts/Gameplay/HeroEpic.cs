using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEpic : MonoBehaviour
{
    //[SerializeField]
    //private Behaviour _turnoffthis;

    public Animator _anim;
    public int scoreCommon; //���� ����� �� ������ ������
    public CommonHeroGainCauldron3 colorCouldron;

    [SerializeField]
    private GameObject PlayAudioDeathG;

    public Animation anim; //�������� ����� ���������
    //public float threshold;
    Transform target;
    //public Vector3 target;
    [SerializeField]
    private float speed;

    [SerializeField]
    private int lives = 60;
    [SerializeField]
    private int maxlives = 60;
   

    protected SpriteRenderer spriteRenderer;
    private Coroutine moveRoutine;
    private void Start()
    {
        target = GameObject.FindWithTag("EnemyWeak").GetComponent<Transform>();
        speed = 1;
         _anim = GetComponentInChildren<Animator>();
        // _turnoffthis.enabled = false;
        FindGameController();
        PlayAudioDeathG.SetActive(false);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
       
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
            Debug.Log("������ �� ������");
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        if (target == null)
            return;
        if (lives <= 0)
        {
            DeathEpicHero();
        }
        else
        {
            return;
        }
        

    }
    public void UpdateTarget()
    {
        target = GameObject.FindWithTag("EnemyWeak2").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
    
    public void Dead1()
    {
        colorCouldron.Death11();
    }


    private void DeathEpicHero()
    {
        _anim.SetTrigger("Death");
        Dead1(); //������ ����� ����� ����� ������
        PlayAudioDeathG.SetActive(true);
        colorCouldron.DamagePlayerHP(scoreCommon);
        Debug.Log("������� ����� ��������!");
        //Destroy(gameObject, 0.30f); // ��� ��������� ������ �����
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
            //speed = 0;
            Debug.Log("���� � ������ ������������ � ������!");

        }
        //else
        //{
           // Debug.Log("���� �� � ���");
            //_anim.SetTrigger("Moving");
           // speed = 1;

       // }
        if (collision.tag == "EnemySword")
        {
            Damage(1);
            colorCouldron.DamagePlayerHP(scoreCommon);
            Debug.Log("����� ������� ����:");
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
            Debug.Log("������ ������������� ������!");
            TakeRangeDamageCommon();

        }

    }
}
