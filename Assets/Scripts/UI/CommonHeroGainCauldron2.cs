using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommonHeroGainCauldron2 : MonoBehaviour
{
    public AudioClip ouchAudio;
    public GameObject _commonHeroCard1;
    public GameObject _commonHeroCard2;
    public GameObject _commonHeroCard3;
    public GameObject _commonHeroCard4;
    public GameObject _rareHeroCard1;
    public GameObject _rareHeroCard2;
    public GameObject _rareHeroCard3;
    
    public GameObject _epicHeroCard1;
    
    public GameObject BattleButtonCommon1;
    public GameObject BattleButtonRare1;
    public GameObject BattleButtonEpic1;

    public Text CommonHeroText;
    public Text RareHeroText;
    public Text EpicHeroText;

    public int scoreCommonHero;
    public int scoreRareHero;
    public int scoreEpicHero;

    public int CommonArmy = 0;
    public int RareArmy = 0;
    public int EpicArmy = 0;
   
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
            Debug.Log("ScoreHelper не найден!");
        }

       

        BattleButtonCommon1.SetActive(false);
        BattleButtonRare1.SetActive(false);
        BattleButtonEpic1.SetActive(false);
        //scoreCommonHero = 4;
       // scoreRareHero = 1;
       // scoreEpicHero = 0;
        UpdateScore();


    }

    private void Update()
    {
        if (scoreCommonHero <= 0)
        {
            scoreCommonHero = 0;

        }
        if (scoreRareHero <= 0)
        {
            scoreRareHero = 0;

        }
        if (scoreEpicHero <= 0)
        {
            scoreEpicHero = 0;

        }

        if (CommonArmy ==1)
        {
            BattleButtonCommon1.SetActive(true);
            BattleButtonRare1.SetActive(false);
            Debug.Log("Обычная битва активированна!");

        }
        if (CommonArmy <= 0)
        {
            CommonArmy = 0;

        }
        if (RareArmy <= 0)
        {
            RareArmy = 0;

        }
        if (EpicArmy <= 0)
        {
            EpicArmy = 0;

        }

        if (RareArmy == 1)
        {
            BattleButtonRare1.SetActive(true);
            BattleButtonCommon1.SetActive(false);
            
            Debug.Log("Редкая битва активированна!");

        }
        if (RareArmy == 1)
        {

            GainRare1();
        }
        if (RareArmy == 2)
        {

            GainRare2();
        }
        if (RareArmy == 3)
        {

            GainRare3();
        }

        if (CommonArmy == 1)
        {

            GainCommon1();
        }
        if (CommonArmy == 2)
        {

            GainCommon2();
        }
        if (CommonArmy == 3)
        {

            GainCommon3();
        }
        if (CommonArmy == 4)
        {

            GainCommon4();
        }


        if (EpicArmy >= 1)
        {
            BattleButtonRare1.SetActive(false);
            BattleButtonCommon1.SetActive(false);
            BattleButtonEpic1.SetActive(true);
            Debug.Log("Эпичная битва активированна!");
            GainEpic1();

        }
    }

    void UpdateScore()
    {
        CommonHeroText.text = ": " + scoreCommonHero;
        RareHeroText.text = ": " + scoreRareHero;
        EpicHeroText.text = ": " + scoreEpicHero;
        

    }

    public void LessCommonHero (int newCommonValueLess)
    {
        //scoreCommonHero;
        UpdateScore();
    }    
    public void AddCommonHeroes(int newCommonValueHero)
    {
        scoreCommonHero += 1;
        UpdateScore();
    }

    public void AddRareHeroes(int newRareValueHero)
    {
        scoreRareHero += 1;
        UpdateScore();
    }
    public void LessRareHero(int newCommonValueLess)
    {
        scoreRareHero -= 1;
        UpdateScore();
    }

    public void AddEpicHeroes(int newRareValueHero)
    {
        scoreEpicHero += 1;
        UpdateScore();
    }


    public void GainCommon1()
    {
        _commonHeroCard1.SetActive(true);
    }
    public void GainCommon2()
    {
        _commonHeroCard2.SetActive(true);
    }
    public void GainCommon3()
    {
        _commonHeroCard3.SetActive(true);
    }
    public void GainCommon4()
    {
        _commonHeroCard4.SetActive(true);
    }

    public void GainRare1()
    {
        _rareHeroCard1.SetActive(true);
    }
    public void GainRare2()
    {
        _rareHeroCard2.SetActive(true);
    }
    public void GainRare3()
    {
        _rareHeroCard3.SetActive(true);
    }

    public void GainEpic1()
    {
        _epicHeroCard1.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CommonHero")
        {
            scoreHelper.AddCommonHero(1);
            //scoreCommonHero -= 1;
            // CommonArmy += 1;
            Debug.Log("Получен 1-й обычный герой");
           // UpdateScore();

        }


        if (collision.gameObject.tag == "RareHero")
        {
            //GainRare1();
            scoreRareHero -= 1;
            RareArmy += 1;
            Debug.Log("Получен 1 редкий герой");
            UpdateScore();

        }
        if (collision.gameObject.tag == "RareHero1")
        {
            //GainRare2();
            scoreRareHero -= 1;
            RareArmy += 1;
            Debug.Log("Получен 1 редкий герой");
            UpdateScore();

        }

        if (collision.gameObject.tag == "EpicHero")
        {
           
            scoreEpicHero -= 1;
            EpicArmy += 1;
            Debug.Log("Получен 1 эпический герой");

        }

    }
}
