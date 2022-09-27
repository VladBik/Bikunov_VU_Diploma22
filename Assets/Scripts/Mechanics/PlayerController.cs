using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using UnityEngine.UI;


namespace Platformer.Mechanics
{

    public class PlayerController : KinematicObject
    {
        [SerializeField] 
        private Behaviour _shooting;

        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        public int lives = 3;
        //public Rigidbody2D rb2D;

        //public GameObject DamageSound;

        public float maxSpeed = 7;

        public float jumpTakeOffSpeed = 7;
        public float trapsTakeOffSpeed = 1;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/
        public Collider2D collider2d;
        /*internal new*/
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        public GameObject FullHeart1;
        public GameObject FullHeart2;
        public GameObject FullHeart3;
        public GameObject pLost;
        [SerializeField]
        private GameObject pWin2;
        [SerializeField]
        private GameObject _PokazTutoraFirst;

        public GameObject GarlicTut;

        public GameObject ColorPoints1;
        public GameObject ColorPoints2;
        public GameObject ColorPoints3;
        public GameObject ColorPoints4;
        public GameObject ColorPoints5;
        public GameObject ColorPoints6;
        public GameObject ColorPoints7;
        public GameObject ColorPoints8;
        public GameObject SpherePoints1;
        public GameObject SpherePoints2;
        public GameObject SpherePoints3;

        public GameObject Light1;
        public GameObject Light2;
        public GameObject Light3;
        public GameObject Light4;

        public GameObject Talk1;
        public GameObject Talk2;
        public GameObject Talk3;
        public GameObject Talk4;

        //Временно, пока отвалился менеджер очков
        //[SerializeField]
        //  private int scorecolors;
        //  [SerializeField]
        //  private int scoresecretcolors;
        // [SerializeField]
        //private int herospheres;


        // public Text scorecolorsText;
        // public Text herospheresText;

        [SerializeField]
        private int herospheresLost;
        [SerializeField]
        private int scorecolorsLost;
        [SerializeField]
        private int herospheresWin;
        [SerializeField]
        private int scorecolorsWin;
        //[SerializeField]
        // private int herospheresWin;
        // [SerializeField]
        // private int scorecolorsWin;

        public Text scorecolorsLostText;
        public Text herospheresLostText;
        public Text scorecolorsWinText;
        public Text herospheresWinText;


        //Конец временного кода

        public Transform transformPoint;
        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        public bool paused;

        //---Уровни----
        public GameObject lvl2;
        public GameObject lvl1;
        //---Уровни.Конец----

        //void Start()
        // {

        // FullHeart1.SetActive(true);
        //FullHeart2.SetActive(true);
        // }
        public Rigidbody2D rigidbody;
        void Awake()
        {
            AudioListener.pause = false;
            Time.timeScale = 1f;
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
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
            //Временно
        }

        void UpdateScore()
        {
            //scorecolorsText.text = ": " + scorecolors;
           // herospheresText.text = ": " + herospheres;

            scorecolorsLostText.text = ": " + ScoreHelper.scorecolors;
            herospheresLostText.text = ": " + ScoreHelper.herospheres;
            herospheresLost = ScoreHelper.herospheres;
            scorecolorsLost = ScoreHelper.scorecolors;

            scorecolorsWinText.text = ": " + herospheresWin;
            herospheresWinText.text = ": " + scorecolorsWin;
            herospheresWin = ScoreHelper.herospheres;
            scorecolorsWin = ScoreHelper.scorecolors; 


    }

        protected override void Update()
        {
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();

            if (lives <= 0)
            {
                UpdateScore();
                //player.animator.SetBool("dead", true);
                maxSpeed = 0;
                //jump = 0;
                //force = 0;
                //Destroy(gameObject, 0.8f);
                pLost.SetActive(true);
                //PlayAudio2.SetActive(true);
                //PlayAudio1.SetActive(false);
                //TimerSec.SetActive(false);
                //JumpButton1.SetActive(false);
                Time.timeScale = 0f;
            }

            if (lives >= 3)
            {
                FullHeart1.SetActive(true);
                FullHeart2.SetActive(true);
            }
            if (lives == 2)
            {
                FullHeart1.SetActive(false);
                FullHeart2.SetActive(true);
            }
            if (lives == 1)
            {
                FullHeart1.SetActive(false);
                FullHeart2.SetActive(false);
            }
            if (lives <= 0)
            {
                FullHeart1.SetActive(false);
                FullHeart2.SetActive(false);
                FullHeart3.SetActive(false);
            }

            if (scorecolorsLost == 1)
            {
                ColorPoints1.SetActive(true);
                Light1.SetActive(false);
                Talk1.SetActive(true);

            }

            if (scorecolorsLost == 2)
            {
                ColorPoints2.SetActive(true);
                Light2.SetActive(false);
                Talk2.SetActive(true);

            }
            if (scorecolorsLost == 3)
            {
                ColorPoints3.SetActive(true);
                Light3.SetActive(false);
                Talk3.SetActive(true);

            }
            if (scorecolorsLost == 4)
            {
                ColorPoints4.SetActive(true);
                Light4.SetActive(false);
                Talk4.SetActive(true);

            }

            if (herospheresLost == 1)
            {
                SpherePoints1.SetActive(true);

            }
            if (herospheresLost == 2)
            {
                SpherePoints2.SetActive(true);

            }
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        private void AddHp()
        {
            if (lives < 3)
            {
                lives += 1;
            }

            if (lives > 3)
            {
                lives = 3;
            }
        }

        private void TakeDamage()
        {
            lives -= 1;
            //rigidbody.AddForce(transform.up * 3.0F, ForceMode2D.Impulse);
            velocity.y = trapsTakeOffSpeed;

            Debug.Log(lives);

            if (lives < 0)
            {
                lives = 0;
            }

        }

        private void TakeDamage2()
        {
            lives -=3;

            if (lives < 0)
            {
                lives = 0;
            }
        }

        private void TransformP()
        {
            //new Vector3(935.19f, 4844.06f, 0)
            transform.position = transformPoint.position;
            Debug.Log("2 уровень начался");
            Time.timeScale = 0;
            lvl1.SetActive(false);
            lvl2.SetActive(true);
            UpdateScore();

        }


        //private void TransformP2()
      //  {
            //transform.position = transformPoint.position;
          //  Debug.Log("2 кончился");
          //  Time.timeScale = 0;
          //  pWin2.SetActive(false);
            //lvl2.SetActive(false);
      //  }

        // private void TransformP3()
        // {
        // transform.position = new Vector3(-8.03f, 0.54f, 0);
        //animator.SetTrigger("NewGame");
        // speed = 4;
        // lives = 3;
   // }

            private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "ExitLevel")
            {

                TransformP();
                Debug.Log("Коснулся тп");
                UpdateScore();

            }

            if (collision.gameObject.tag == "Exitlvl2")
            {
                
                Debug.Log("Lvl 2 complete!");
                Time.timeScale = 0;

                pWin2.SetActive(true);
                
               

            }
            if (collision.gameObject.tag == "GarlicTutor")
            {

               GarlicTut.SetActive(true);

            }
            

            if (collision.gameObject.tag == "ColorPoint")
            {
                //scorecolors += 1;
                Debug.Log("Получен 1 осколок цвета Player");
                
                UpdateScore();
            }

            if (collision.gameObject.tag == "HeroSphere")
            {
                //herospheres += 1;
                Debug.Log("Получена 1 сфера обычного героя Player");
               
                UpdateScore();
            }

            if (collision.gameObject.tag == "Medicine")
            {
                AddHp();
                
            }

            if (collision.gameObject.tag == "Enemy")
            {
                TakeDamage();
            }
            if (collision.gameObject.tag == "SpikesTrap1")
            {
                TakeDamage();
                velocity.y = trapsTakeOffSpeed + 3;
                //* model.jumpModifier

            }

            if (collision.gameObject.tag == "UpTrap")
            {
                TakeDamage2();
            }
            if (collision.gameObject.tag == "ControlTut1")
            {
                _PokazTutoraFirst.SetActive(true);
            }



            //if (collision.gameObject.tag == "Teleport2")
            // {
            // TransformP2();
            // }
            if (collision.gameObject.tag == "Garlic")
            {
                _shooting.enabled = true;
            }
           
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}