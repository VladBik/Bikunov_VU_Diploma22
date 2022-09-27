using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverKey1 : MonoBehaviour
{
  
    public GameObject item1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            item1.SetActive(true);
            Debug.Log("Получен 1 серебрянный ключ");
            Destroy(gameObject, 0.15f);
        }
    }
}
