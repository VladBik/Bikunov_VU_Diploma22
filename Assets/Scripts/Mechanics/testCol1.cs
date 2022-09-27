using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCol1 : MonoBehaviour
{
   [SerializeField]
    private GameObject AudDColl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudDColl.SetActive(true);
            Destroy(gameObject, 0.3f);
        }

    }
}
