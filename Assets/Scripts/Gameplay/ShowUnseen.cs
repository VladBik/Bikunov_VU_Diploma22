using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnseen : MonoBehaviour
{
    public GameObject Secret1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Secret1.SetActive(true);

        }

       
    }
}

