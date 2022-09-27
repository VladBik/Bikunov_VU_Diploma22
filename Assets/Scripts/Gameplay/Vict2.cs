using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    public class Vict2 : MonoBehaviour
    {
        public GameObject pWin;
        public GameObject _docHero;
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
                pWin.SetActive(true);
                pWin.SetActive(false);
                Debug.Log("Player Complete Level!");
                Time.timeScale = 0f;

            
        }
    }
}


