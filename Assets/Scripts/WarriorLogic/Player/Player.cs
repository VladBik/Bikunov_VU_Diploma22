using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour //, IDamageable
{
    private Rigidbody2D rigidbody2D;
    //private Transform transform;
    [SerializeField]
    private  float force = 5.0f;
    [SerializeField]
    private  float _basespeed = 3.0f;
    [SerializeField]
    private  float speed;
    [SerializeField]
    private Vector2 jumpForce;
    [SerializeField]
    private float _hitforce = 3;


    [SerializeField]
    private float max_depth = 0.6f;
    private Collider2D collider2D;
    [SerializeField]
    private LayerMask layerMask;
    private bool resetJump = true;
    private PlayerAnimation _playeranim;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _swordArc;
    private Animator animator;

    public GameObject FullHeart1;
    public GameObject FullHeart2;
    public GameObject FullHeart3;
    public GameObject FullHeart1a;
    public GameObject FullHeart1b;

    public GameObject Platf1;
    public GameObject ColorPoints1;
    public GameObject ColorPoints2;
    public GameObject ColorPoints3;
    public GameObject ColorPoints4;

    public GameObject SpherePoints1;
    public GameObject RareSpherePoints1;

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;

    public GameObject Talk1;
    public GameObject Talk2;
    public GameObject Talk3;
    public GameObject Talk4;

    public Transform transformPoint;



    //Временно, пока отвалился менеджер очков
    [SerializeField]
    public  int scorecolors;
    [SerializeField]
    public  int scoresecretcolors;
    [SerializeField]
    public  int herospheres;
    [SerializeField]
    private int herospheresLost;
    [SerializeField]
    private int scorecolorsLost;
    [SerializeField]
    private int trapsTakeOffSpeed;

    public Text scorecolorsText;
    public Text scoresecretcolorsText;
    public Text herospheresText;

    public Text scorecolorsLostText;
    public Text herospheresLostText;
    public Text scoresecretcolorsLostText;

    public Text scorecolorsWinText;
    public Text herospheresWinText;
    public Text scoresecretcolorsWinText;

    public AudioSource audioSource;

    public bool paused;

    //Конец временного кода

    public GameObject pLost;
    public GameObject pWin;

    // public int Health { get; set; }
    [SerializeField]
    private int Health = 5;

    // Start is called before the first frame update
    public void Damage(int damage)
    {
        if (_playeranim.GetAnimationsStateInfo().IsName("Hit")) return;
        Health -= damage;
        audioSource.Play();
        _playeranim.Hit();
        if (Health <= 0)
        {
            pLost.SetActive(true);
            Debug.Log("Player Has Died");
            Time.timeScale = 0f;
            speed = 0;
            force = 0;
            //Destroy(gameObject, 0.10f);
        }
    }


void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //transform = GetComponent<Transform>();
        collider2D = GetComponent<Collider2D>();
        _playeranim = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordArc = transform.GetChild(1).GetComponent<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        //Health = 5;
        speed = _basespeed;
        AudioListener.pause = false;
        jumpForce = new Vector2(0, force);
        pLost.SetActive(false);
        //scoresecretcolors = herospheres; //убрать при добавлении секретных очков
        UpdateScore();
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1f;
        _basespeed = 3.0f;
        force = 5.0f;


        ColorPoints1.SetActive(false);
        ColorPoints2.SetActive(false);
        ColorPoints3.SetActive(false);
        ColorPoints4.SetActive(false);

        Light1.SetActive(true);
        Light2.SetActive(true);
        Light3.SetActive(true);
        Light4.SetActive(true);
        Talk1.SetActive(false);
        Talk2.SetActive(false);
        Talk3.SetActive(false);
        Talk4.SetActive(false);
        UpdateScore();

    }

    void UpdateScore()
    {
        scorecolorsText.text = ": " + scorecolors;
        herospheresText.text = ": " + herospheres;
        scoresecretcolorsText.text = ": " + scoresecretcolors;

        scorecolorsLostText.text = ": " + scorecolors;
        herospheresLostText.text = ": " + herospheres;
        scoresecretcolorsLostText.text = ": " + scoresecretcolors;

        scorecolorsWinText.text = ": " + scorecolors;
        herospheresWinText.text = ": " + herospheres;
        scoresecretcolorsWinText.text = ": " + scoresecretcolors;

        

}

    
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
        Movement();
        Attack();
        SprintPlayer();
        //Debug.Log(transform.position);
        Debug.DrawRay(transform.position, Vector2.down * max_depth, Color.green);
        UpdateScore(); //под вопросом
       
        if (Health >= 5)
        {
            FullHeart1b.SetActive(true); //1
            FullHeart1a.SetActive(true); //2
            FullHeart1.SetActive(true); //3
            FullHeart2.SetActive(true); //4
            FullHeart3.SetActive(true); //5
        }

        if (Health == 4)
        {
            FullHeart1b.SetActive(false); //1
            FullHeart1a.SetActive(true); //2
            FullHeart1.SetActive(true); //3
            FullHeart2.SetActive(true); //4
            FullHeart3.SetActive(true); //5
        }
        if (Health == 3)
        {
            FullHeart1b.SetActive(false); //1
            FullHeart1a.SetActive(false); //2
            FullHeart1.SetActive(true); //3
            FullHeart2.SetActive(true); //4
            FullHeart3.SetActive(true); //5
        }
        if (Health == 2)
        {
            FullHeart1b.SetActive(false); //1
            FullHeart1a.SetActive(false); //2
            FullHeart1.SetActive(false);
            FullHeart2.SetActive(true);
            FullHeart3.SetActive(true); //5
        }
        if (Health == 1)
        {
            FullHeart1b.SetActive(false); //1
            FullHeart1a.SetActive(false); //2
            FullHeart1.SetActive(false); //3
            FullHeart2.SetActive(false); //4
            FullHeart3.SetActive(true); //5
        }
        if (Health <= 0)
        {
            Health = 0;
            FullHeart1b.SetActive(false); //1
            FullHeart1a.SetActive(false); //2
            FullHeart1.SetActive(false); //3
            FullHeart2.SetActive(false); //4
            FullHeart3.SetActive(false); //5
            pLost.SetActive(true);
            Debug.Log("Player Has Died");
            Time.timeScale = 0f;
            speed = 0;
            force = 0;
            AudioListener.pause = true;
        }

        if (scorecolors == 1)
        {
            ColorPoints1.SetActive(true);
            Light1.SetActive(false);
            Talk1.SetActive(true);

        }

        if (scorecolors == 2)
        {
            ColorPoints2.SetActive(true);
            Light2.SetActive(false);
            Talk2.SetActive(true);

        }
        if (scorecolors == 3)
        {
            ColorPoints3.SetActive(true);
            Light3.SetActive(false);
            Talk3.SetActive(true);

        }
        if (scorecolors == 4)
        {
            ColorPoints4.SetActive(true);
            Light4.SetActive(false);
            Talk4.SetActive(true);

        }

        if (herospheres >= 1)
        {
            SpherePoints1.SetActive(true);

        }
        if (scoresecretcolors == 1)
        {
            RareSpherePoints1.SetActive(true);

        }

        UpdateScore();
    }

    void Attack()
    {
        if (IsGrounded() && Input.GetMouseButtonDown(0))
        {
            //attack starts 

            _playeranim.Attacking();
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            //if(speed!=0)
            //startcoroutine(cooldown(0.7f));
        }
        //_playeranim.StopAttacking();
    }
    void SprintPlayer()
    {
        //Debug.Log("Player is moving with a speed : " + speed);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 1.5f * _basespeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = _basespeed;
        }
    }
    IEnumerator CoolDown(float time)
    {
        var temp_speed = speed;
        speed = 0;
        yield return new WaitForSeconds(time);
        speed = temp_speed;
    }
    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, max_depth, layerMask);
        if (raycastHit2D.collider != null)
        {
            if (resetJump)
                return true;
            //Debug.Log("Hitted : " + raycastHit2D.collider.name);
            return false;
        }
        else return false;

    }
    void FlipPlayer(float move)
    {
        if (move < 0)
        {
            _spriteRenderer.flipX = true;
            _swordArc.flipX = true;
            _swordArc.flipY = true;
            Vector3 newpos = _swordArc.transform.localPosition;
            newpos.x = -1.01f;
            _swordArc.transform.localPosition = newpos;
        }
        if (move > 0)
        {
            _spriteRenderer.flipX = false;
            _swordArc.flipX = false;
            _swordArc.flipY = false;
            Vector3 newpos = _swordArc.transform.localPosition;
            newpos.x = 1.01f;
            _swordArc.transform.localPosition = newpos;
        }
    }
     //private void TransformP()
       // {
       // transform.position = transformPoint.position;
            //new Vector3(-126.0f, 0f, 0);
             
       // }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, force);
            _playeranim.jumping(!IsGrounded());
            resetJump = false;
            StartCoroutine(ResetJumpNeeded());
        }
        _playeranim.jumping(!IsGrounded());
        rigidbody2D.velocity = new Vector2(move * speed, rigidbody2D.velocity.y);
        FlipPlayer(move);
        _playeranim.Move(move);

    }

    IEnumerator ResetJumpNeeded()
    {
        yield return new WaitForSeconds(0.1f);
        resetJump = true;
    }

    private void AddHp()
    {
        if (Health <= 5)
        {
            Health += 1;
        }

        if (Health > 5)
        {
            Health = 5;
        }
    }
    public void AddHpCheat()
    {
     
            Health += 5;
    
       
    }

    private void TakeDamage()
    {
        Health -= 1;
        Damage(1);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, _hitforce);
       
        audioSource.Play();
        // rb2D.AddForce(transform.position * 0.5F, ForceMode2D.Impulse);
        // DamageSound.SetActive(true);
        if (Health < 0)
        {
            Health = 0;
        }

    }

    private void TakeDamage2()
    {
        Health -= 5;
        audioSource.Play();
        Damage(5);
        if (Health < 0)
        {
            Health = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColorPoint")
        {
            scorecolors += 1;
            Debug.Log("Получен 1 осколок цвета");
            UpdateScore();
        }

        if (collision.gameObject.tag == "HeroSphere")
        {
            herospheres += 1;
            Debug.Log("Получена 1 сфера обычного героя");
            UpdateScore();
        }
        if (collision.gameObject.tag == "HeroSphereRare")
        {
            scoresecretcolors += 1;
            Debug.Log("Получена 1 сфера редкого героя");
            UpdateScore();
        }

        if (collision.gameObject.tag == "Medicine")
        {
            AddHp();

        }

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage();
            
            audioSource.Play();
        }

        if (collision.gameObject.tag == "UpTrap")
        {
            TakeDamage2();
            Debug.Log("Получен урон от Давилки");
            audioSource.Play();
        }
        if (collision.gameObject.tag == "SpikesTrap1")
        {
            audioSource.Play();
           // TakeDamage();
            Damage(1);
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, _hitforce);
            Debug.Log("Получен урон от щипов");
        }

        if (collision.gameObject.tag == "SpiderClaw1")
        {
            audioSource.Play();
            // TakeDamage();
            Damage(1);
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, _hitforce);
            Debug.Log("Получен кусь от паукана");
        }
        if (collision.gameObject.tag == "SkeletonAxe1")
        {
            audioSource.Play();
            // TakeDamage();
            Damage(2);
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, _hitforce);
            Debug.Log("Получен удар от скелета");
        }

        if (collision.gameObject.tag == "SmallRock1")
        {
            audioSource.Play();
            // TakeDamage();
            Damage(1);
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, _hitforce);
            Debug.Log("Получен удар от камешка");
        }


        if (collision.gameObject.tag == "Teleport")
        {
           //TransformP();
        }
        if (collision.gameObject.tag == "Trig2")
        {
           Platf1.SetActive(true);
        }

        if (collision.gameObject.tag == "Teleport2")
        {
            // TransformP2();
        }
       // //if (collision.gameObject.tag == "Garlic")
       // {
           // _shooting.enabled = true;
       // }
       
        if (collision.gameObject.tag == "ExitLevel")
        {
            //if (!paused)
            // {
            Time.timeScale = 0;
            paused = true;
            AudioListener.pause = true;
            // }
            // else
            // {
            //Time.timeScale = 1;
            // paused = false;
        }

        if (collision.gameObject.tag == "ExitLvlWarrior1")
        {
            //if (!paused)
            // {
            Time.timeScale = 0;
            paused = true;
            AudioListener.pause = true;
            pWin.SetActive(true);
            Debug.Log("Уровень пройден!");
            // }
            // else
            // {
            //Time.timeScale = 1;
            // paused = false;
        }
    }
}
