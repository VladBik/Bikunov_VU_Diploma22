using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAud : MonoBehaviour
{
    //public GameObject DmgAud;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            //DmgAud.SetActive(true);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
       // if (collision.gameObject.tag == "Player")
       // {
            //DmgAud.SetActive(false);
       // }
   // }
}
