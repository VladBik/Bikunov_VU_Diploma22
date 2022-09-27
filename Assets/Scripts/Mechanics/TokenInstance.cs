using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    
    [RequireComponent(typeof(Collider2D))]
    public class TokenInstance : MonoBehaviour
    {
        public int scorecolors;
        public ScoreHelper scoreHelper;

        public AudioClip tokenCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        //unique index which is assigned by the TokenController in a scene.
        internal int tokenIndex = -1;
        internal TokenController controller;
        //active frame in animation, updated by the controller.
        internal int frame = 0;
        internal bool collected = false;

        void Awake()
        {
            GameObject GameControllerObject = GameObject.FindWithTag("ScoreHelper");
            if (GameControllerObject != null)
            {
                scoreHelper = GameControllerObject.GetComponent<ScoreHelper>();
            }
            if (GameControllerObject == null)
            {
                Debug.Log("ScoreHelper не найден!");
            }

            _renderer = GetComponent<SpriteRenderer>();
            if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;

            
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //Только если игрок зашел
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player);
        }

        void OnPlayerEnter(PlayerController player)
        {
            scoreHelper.AddScorecolors(scorecolors);
            
            if (collected) return;
            
            frame = 0;
            sprites = collectedAnimation;
            if (controller != null)
                collected = true;
            
            var ev = Schedule<PlayerTokenCollision>();
            ev.token = this;
            ev.player = player;
        }
    }
}