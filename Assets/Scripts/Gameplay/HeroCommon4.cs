using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCommon4 : MonoBehaviour
{
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
    private int lives = 3;
    protected SpriteRenderer spriteRenderer;
    private Coroutine moveRoutine;
    private void Start()
    {

        target = GameObject.FindWithTag("EnemyWeak2").GetComponent<Transform>();
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
        Debug.Log("������� ����� ��������!");
        //Destroy(gameObject, 0.30f); // ��� ��������� ������ �����
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _anim.SetTrigger("Hit");
            speed = 0;
            Debug.Log("����� � ������ ������������ � ������!");

        }
        else
        {
            target = GameObject.FindWithTag("EnemyWeak2").GetComponent<Transform>();
            _anim.SetTrigger("Moving");
            speed = 1;

        }


    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "EnemySword")
        {
            TakeDamageCommon();

        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("������ ������������� ������!");
            TakeRangeDamageCommon();

        }

    }
}
