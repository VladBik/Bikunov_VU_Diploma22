using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHero : MonoBehaviour
{
    public ScoreHelper scoreHelper;
  
    public int _epicheronumber;
    

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
            scoreHelper.AddEpicHero(_epicheronumber);
            Debug.Log("Получен эпический герой");
            Destroy(gameObject, 0.5f);
        }

    }
}
