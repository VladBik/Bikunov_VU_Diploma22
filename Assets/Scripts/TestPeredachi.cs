using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPeredachi : MonoBehaviour
{
    public AudioClip ouchAudio;

    public ScoreHelper scoreHelper;


    void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("ScoreHelper");
        if (GameControllerObject != null)
        {
            scoreHelper = GameControllerObject.GetComponent<ScoreHelper>();
        }
        if (GameControllerObject == null)
        {
            Debug.Log("ScoreHelper �� ������!");
        }


    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CommonHero")
        {
            scoreHelper.AddCommonHero(1);
         
            Debug.Log("������� 1-� ������� �����");
        
        }
       

        if (collision.gameObject.tag == "RareHero")
        {
            scoreHelper.AddRareHero(1); 
            Debug.Log("������� 1 ������ �����");
           

        }
       //if (collision.gameObject.tag == "RareHero1")
      //  {
           
          //  Debug.Log("������� 1 ������ �����");
          

       // }

        if (collision.gameObject.tag == "EpicHero")
        {
            scoreHelper.AddEpicHero(1); 

            Debug.Log("������� 1 ��������� �����");

        }

    }
}
