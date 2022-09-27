using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2Enter : MonoBehaviour
{
    
    public GameObject Spawners1;
    public GameObject Platf2;
    public GameObject Aud1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Platf2.SetActive(true);
            Spawners1.SetActive(true);
            Aud1.SetActive(true);
            Debug.Log("Платформы появились");

        }
    }
}
