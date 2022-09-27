using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommonHero2 : MonoBehaviour
{
    public Animator _anim;
    public int scoreCommon; //���� ����� �� ������ ������
    public CommonHeroGainCauldron1 colorCouldron;
    public int deathCount2; //���� �������
    [SerializeField]
    private GameObject PlayAudioDeathG;
    [SerializeField]
    private GameObject EnemyColl1;

    public Animation anim; //�������� ����� ���������
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
        targetPl = GameObject.FindWithTag("HeroWeak2").GetComponent<Transform>();
        _anim = GetComponentInChildren<Animator>();
        // _turnoffthis.enabled = false;
        FindGameController();
        PlayAudioDeathG.SetActive(false);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim["SlimeAtt1 Animation"].speed = 0.3f;
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
        anim["SlimeAtt1 Animation"].speed += 1;
    }
    private void DeathCounting()
    {
        colorCouldron.DeathCount(deathCount2);
        Debug.Log("���� ������");

    }
    private void DeathCommonEnemy()
    {
        EnemyColl1.SetActive(false);
        _anim.SetTrigger("Death");
        anim["SlimeAtt1 Animation"].speed = 0f;
        PlayAudioDeathG.SetActive(true);
        colorCouldron.DamageEnemyHP(scoreCommon);
        
        Debug.Log("���� ��������!");
        speed = 0;
        Destroy(gameObject); // ��� ��������� ������ �����
        if (livesEnem <= 0)
        {
            livesEnem = 0;

        }
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
            Debug.Log("������ �� ������");
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _anim.SetTrigger("Hit");
            //speed = 0;
            Debug.Log("����� � ������ ������������ � ������!");

        }
        if (collision.gameObject.tag == "Sword")
        {
            Damage(1);
            colorCouldron.DamageEnemyHP(scoreCommon);
            if (livesEnem <= 0)
            {
                livesEnem = 0;

                Debug.Log(gameObject.name + " is dead ");
                //Destroy(gameObject, 0.30f);
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






    private void OnTriggerEnter(Collider collision)
    {
        //if (collision.tag == "Sword")
        //  {
        // livesEnem -= 1;


        // }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("������ ������������� ������!");
            TakeRangeDamageCommon();

        }
        else return;

    }
}
