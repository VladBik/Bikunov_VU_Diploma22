using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest22 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("HeroSphere"))
        {
            TextTest._colorsNumber += 1;
            Debug.Log("Collision");
            Destroy(collision.gameObject);
        }
    }
}
