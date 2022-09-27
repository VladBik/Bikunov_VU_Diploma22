using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
   [SerializeField]
    private int _hitDMG = 1;
   // private void OnTriggerEnter2D(Collider2D collision)
    //{
        //Player player = GetComponentInParent<Player>();


        //if (collision.gameObject.tag == "Enemy")
       // {
           // IDamageable hit = collision.GetComponentInParent<IDamageable>();
           // if (hit != null)
           // {
              //  Debug.Log("Damaged");
              //  hit.Damage(_hitDMG);

          //  }
           // Debug.Log("Hitted: " + collision.name);
       // }

       private void OnTriggerEnter2D(Collider2D other)
    {
        //Player player = GetComponentInParent<Player>();


        IDamageable hit = other.GetComponentInParent<IDamageable>();
        if (hit != null)
        {
            Debug.Log("Damaged");
            hit.Damage(_hitDMG);

        }
        Debug.Log("Hitted: " + other.name);
    }






}


