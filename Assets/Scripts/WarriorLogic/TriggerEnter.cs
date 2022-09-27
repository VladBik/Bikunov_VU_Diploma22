using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{

    public GameObject Obval1;
    public GameObject Aud1;
    public GameObject Platf1;
    public GameObject Spawners1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Obval1.SetActive(true);
           Platf1.SetActive(true);
            Spawners1.SetActive(true);
            Aud1.SetActive(true);
            Debug.Log("Обвал пошел");

        }
    }
}