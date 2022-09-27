using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainRareHero : MonoBehaviour
{
    public ScoreHelper scoreHelper;

    //public int _rareheronumber;


    private void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("ScoreHelper");
        if (GameControllerObject != null)
        {
            scoreHelper = GameControllerObject.GetComponent<ScoreHelper>();
        }
        if (GameControllerObject == null)
        {
            Debug.Log("ScoreHelper не найден");
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColorCauldron")
        {
           // scoreHelper.AddRareHero(_rareheronumber);
            Debug.Log("Получен редкий герой");
            Destroy(gameObject);
        }

    }
}
