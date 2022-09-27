using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainCommonHero : MonoBehaviour
{
    public CommonHeroGainCauldron1 paintWell;

    public int _commonheronumber;
    public GameObject TimerOff1;


    private void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("ColorCauldron");
        if (GameControllerObject != null)
        {
            paintWell = GameControllerObject.GetComponent<CommonHeroGainCauldron1>();
        }
        if (GameControllerObject == null)
        {
            Debug.Log("Well не найден");
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColorCauldron")
        {
            paintWell.LessCommonHero(_commonheronumber);
            Debug.Log("Потрачен обычный герой");
            Destroy(gameObject, 0.5f);
        }
       
        if (collision.gameObject.tag == "CommonHero")
        {
            paintWell.LessCommonHero(_commonheronumber);
            TimerOff1.SetActive(false);
            Debug.Log("Потрачен обычный герой");
            Destroy(gameObject, 0.5f);
        }
    }
}
