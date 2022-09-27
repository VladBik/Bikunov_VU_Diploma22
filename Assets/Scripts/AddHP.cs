using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class AddHP : MonoBehaviour
    {


        public AudioSource tokenCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;



        internal int frame = 0;
        internal bool collected = false;

        void Awake()
        {
            tokenCollectAudio = GetComponent<AudioSource>();

            _renderer = GetComponent<SpriteRenderer>();
            if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;


        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {

                Debug.Log("Игрок взял Сердце");
                tokenCollectAudio.Play();
                Destroy(gameObject, 0.3f);
            }

        }
    }
}
