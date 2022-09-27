using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    
    public class VictoryZone : MonoBehaviour
    {
        public GameObject pWin;
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
                pWin.SetActive(true);
                Debug.Log("Player Complete Level!");
                Time.timeScale = 0f;
                
            }
        }
    }
}