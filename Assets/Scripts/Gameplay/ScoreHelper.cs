using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ScoreHelper : MonoBehaviour
{
    public Text scorecolorsText;
    public Text scoresecretcolorsText;
    public Text herospheresText;
    public Text herospheresRareText;
   // public Text colorsWinText;
   // public Text spheresWinText;
    //public Text ColorsLost;
    //public Text SecretColorsLost;
    //public Text SpheresLost;


    public Text _commonheronumberText;
    public Text _RareheronumberText;
    public Text _rareheronumberText;
    public Text _epicheronumberText;
    public Text _legendheronumberText;

    [SerializeField]
    public static  int scorecolors;
    [SerializeField]
    public static int scoresecretcolors;
    [SerializeField]
    public static int herospheres;
   
    public int herospheresRare;
   
    public int herospheresEpic;
   
    public int globalscore;

    public int _commonheronumber;
    public int _rareheronumber;
    public int _epicheronumber;
    public int _legendheronumber;

     

    public GameObject ColorPoints1;
    public GameObject ColorPoints2;
    public GameObject ColorPoints3;
    public GameObject ColorPoints4;
    public GameObject ColorPoints5;
    public GameObject ColorPoints6;
    public GameObject ColorPoints7;
    public GameObject ColorPoints8;

    public GameObject SpherePoints1;
    public GameObject SpherePoints2;
    public GameObject SpherePoints3;

    public GameObject CommonHeroOrb1;
    public GameObject CommonHeroOrb2;
    public GameObject CommonHeroOrb3;
    public GameObject CommonHeroOrb4;

    public GameObject CommonSphere1;
    public GameObject CommonSphere2;
    public GameObject CommonSphere3;
    public GameObject CommonSphere4;

    public GameObject RareSphere1;
    public GameObject RareSphere2;
    public GameObject RareSphere3;

    public GameObject EpicSphere1;
    public GameObject EpicSphere2;

    public GameObject RareHeroOrb1;
    public GameObject RareHeroOrb2;

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


    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;

    [SerializeField]
    private GameObject Talk1;
    [SerializeField]
    private GameObject Talk2;
    [SerializeField]
    private GameObject Talk3;
    [SerializeField]
    private GameObject Talk4;

    //Heroes---------------------
    public GameObject CommonHeroBattle1;
    public GameObject CommonHeroBattle2;
    public GameObject CommonHeroBattle3;
    public GameObject CommonHeroBattle4;

    public GameObject RareHeroBattle1;
    public GameObject RareHeroBattle2;
    public GameObject RareHeroBattle3;
    public GameObject RareHeroBattle4;
    //public GameObject RareHeroBattle4;

    public GameObject EpicHeroBattle1;
    //public GameObject EpicHeroBattle2;
    // public GameObject EpicHeroBattle3;
    // public GameObject EpicHeroBattle4;

    void Start()

    {
       scorecolors = 0;
      scoresecretcolors = 0;
       herospheres = 0;
     //  herospheresRare = 0;
     //  herospheresEpic = 0;
     // globalscore = 0;

        CommonHeroBattle1.SetActive(false);
        CommonHeroBattle2.SetActive(false);
        CommonHeroBattle3.SetActive(false);
        CommonHeroBattle4.SetActive(false);

        RareHeroBattle2.SetActive(false);
        RareHeroBattle3.SetActive(false);
        RareHeroBattle4.SetActive(false);
        //RareHeroBattle1.SetActive(false);

        EpicHeroBattle1.SetActive(false);

        SpherePoints1.SetActive(false);
        SpherePoints2.SetActive(false);
        SpherePoints3.SetActive(false);

        ColorPoints1.SetActive(false);
        ColorPoints2.SetActive(false);
        ColorPoints3.SetActive(false);
        ColorPoints4.SetActive(false);
       

        BattleButtonCommon1.SetActive(false);
        BattleButtonRare1.SetActive(false);
        BattleButtonEpic1.SetActive(false);

        //herospheres = 3;
        // herospheresRare = 1;
        UpdateScore();
    }

    private void FixedUpdate()

    {
        
        if (herospheres == 1)
        {

            CommonHeroOrb1.SetActive(true);
            CommonSphere1.SetActive(true);
            CommonSphere2.SetActive(false);
            CommonSphere3.SetActive(false);
            CommonSphere4.SetActive(false);
        }

        if (herospheres == 2)
        {
            CommonHeroOrb1.SetActive(true);
            CommonHeroOrb2.SetActive(true);
            CommonSphere1.SetActive(true);
            CommonSphere2.SetActive(true);
            CommonSphere3.SetActive(false);
            CommonSphere4.SetActive(false);
        }

        if (herospheres == 3)
        {
            CommonHeroOrb1.SetActive(true);
            CommonHeroOrb2.SetActive(true);
            CommonHeroOrb3.SetActive(true);
            CommonSphere1.SetActive(true);
            CommonSphere2.SetActive(true);
            CommonSphere3.SetActive(true);
            CommonSphere4.SetActive(false);
        }

        if (herospheres == 4)
        {
            CommonSphere1.SetActive(true);
            CommonSphere2.SetActive(true);
            CommonSphere3.SetActive(true);
            CommonSphere4.SetActive(true);
            CommonHeroOrb1.SetActive(true);
            CommonHeroOrb2.SetActive(true);
            CommonHeroOrb3.SetActive(true);
            CommonHeroOrb4.SetActive(true);
        }

        if (herospheresRare == 1)
        {
            RareHeroOrb1.SetActive(true);
            RareSphere1.SetActive(true);
        }

        if (herospheresRare == 2)
        {
            RareSphere1.SetActive(true);
            RareSphere2.SetActive(true);
            RareHeroOrb1.SetActive(true);
            RareHeroOrb2.SetActive(true);
        }

        if (herospheresEpic == 1)
        {
            EpicSphere1.SetActive(true);
        }
        if (_commonheronumber >= 1)
        {
            CommonSphere1.SetActive(false);
            BattleButtonCommon1.SetActive(true);
            BattleButtonRare1.SetActive(false);
            Debug.Log("ќбычна€ битва активированна!");
            GainCommon1();
            herospheres -= 1;

        }
        if (_commonheronumber >= 2)
        {
            CommonSphere2.SetActive(false);
            GainCommon2();
            herospheres -= 1;
        }
        if (_commonheronumber >= 3)
        {
            CommonSphere3.SetActive(false);
            GainCommon3();
            herospheres -= 1;
        }
        if (_commonheronumber >= 4)
        {
            CommonSphere4.SetActive(false);
            GainCommon4();
            herospheres -= 1;
        }
        if (_rareheronumber >= 1)
        {
            RareSphere1.SetActive(false);
            BattleButtonRare1.SetActive(true);
            BattleButtonCommon1.SetActive(false);
            GainRare1();
            herospheresRare -= 1;

            Debug.Log("–едка€ битва активированна!");
        }
        if (_rareheronumber >= 2)
        {
            GainRare2();
            RareSphere2.SetActive(false);
            BattleButtonCommon1.SetActive(false);
            herospheresRare -= 1;
        }
        if (_rareheronumber >= 3)
        {
            GainRare3();
            RareSphere3.SetActive(false);
            BattleButtonCommon1.SetActive(false);
            herospheresRare -= 1;
        }
        if (_epicheronumber >= 1)
        {
            BattleButtonRare1.SetActive(false);
            BattleButtonCommon1.SetActive(false);
            BattleButtonEpic1.SetActive(true);
            Debug.Log("Ёпична€ битва активированна!");
            GainEpic1();
            herospheresEpic -= 1;
        }
        //Colors----------------------------

        if (scorecolors == 1)
        {
            ColorPoints1.SetActive(true);
            Light1.SetActive(false);
            Talk1.SetActive(true);
        }
        if (scorecolors == 2)
        {
            ColorPoints2.SetActive(true);
            Light2.SetActive(false);
            Talk2.SetActive(true);

        }
        if (scorecolors == 3)
        {
            ColorPoints3.SetActive(true);
            Light4.SetActive(false);
            Talk3.SetActive(true);

        }
        if (scorecolors == 4)
        {
            ColorPoints4.SetActive(true);
            Talk4.SetActive(true);

        }
        if (scorecolors == 5)
        {
            ColorPoints5.SetActive(true);
            //Talk4.SetActive(true);

        }
        if (scorecolors == 6)
        {
            ColorPoints6.SetActive(true);
            //Talk4.SetActive(true);

        }
        if (scorecolors == 7)
        {
            ColorPoints7.SetActive(true);
           // Talk4.SetActive(true);

        }
        if (scorecolors == 8)
        {
            ColorPoints8.SetActive(true);
           // Talk4.SetActive(true);

        }

        if (herospheres == 1)
        {
            SpherePoints1.SetActive(true);


        }
       
        if (herospheres <= 0)
        {
            herospheres = 0;


        }
        if (herospheres == 2)
        {
            SpherePoints2.SetActive(true);


        }
        if (herospheres == 3)
        {
            SpherePoints3.SetActive(true);


        }
        UpdateScore();
    }

    void UpdateScore()
    {

        scorecolorsText.text = ": " + scorecolors;
        herospheresText.text = ": " + herospheres;
        scoresecretcolorsText.text = ": " + scoresecretcolors;
        //ColorsLost.text = ": " + scorecolors; 
       // SpheresLost.text = ": " + herospheres; 

       // colorsWinText.text = ": " + scorecolors;
       // spheresWinText.text = ": " + herospheres;

        herospheresRareText.text = ": " + herospheresRare;

        _commonheronumberText.text = ": " + _commonheronumber;
        _RareheronumberText.text = ": " + _rareheronumber;
        _rareheronumberText.text = ": " + _rareheronumber;
        _epicheronumberText.text = ": " + _epicheronumber;
        _legendheronumberText.text = ": " + _legendheronumber;


    }

    public void CommonId1()
    { 
        CommonHeroBattle1.SetActive(true);
        }
    
    public void AddScorecolors(int newScoreValueColor)
    {
        scorecolors += newScoreValueColor;
        UpdateScore();
    }

    public void AddCommonHero(int newScoreValueCommon)
    {
        _commonheronumber += newScoreValueCommon;
        UpdateScore();
    }

    public void AddRareHero(int newScoreValueRare)
    {
        _rareheronumber += newScoreValueRare;
        UpdateScore();
    }
    public void AddEpicHero(int newScoreValueEpic)
    {
        _epicheronumber += newScoreValueEpic;
        UpdateScore();
    }
    public void AddLegendHero(int newScoreValueLegend)
    {
        _legendheronumber += newScoreValueLegend;
        UpdateScore();
    }

    
    public void AddScoresecret(int newScoreValueSecret)
    {
        scoresecretcolors += newScoreValueSecret;
        UpdateScore();
    }

    public void AddScoreHeroSpheres(int newScoreValueSphere)
    {
        herospheres += newScoreValueSphere;
       UpdateScore();
    }

    public void AddScoreHeroSpheresRare(int newScoreValueSphereRare)
    {
        herospheresRare += newScoreValueSphereRare;
        UpdateScore();
    }

    public virtual void GlobalScore()
    {
        globalscore = scoresecretcolors + scorecolors + herospheres;
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

}
