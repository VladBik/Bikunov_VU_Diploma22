using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommonHeroGainCauldron1 : MonoBehaviour
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
    public GameObject BattleButtonRare2;
    public GameObject BattleButtonEpic1;

    public Text CommonHeroText;
    public Text RareHeroText;
    public Text EpicHeroText;

    public int scoreCommonHero = 2;
    public int scoreRareHero = 1;
    public int scoreEpicHero = 0;
    public int CommonArmy = 0;
    public int RareArmy = 0;
    public int EpicArmy = 0;
    //---------HP ----------
    [SerializeField]
    protected int Health = 100;
    [SerializeField]
    protected int HealthEnemy = 20;
    [SerializeField]
    protected int maxHealth = 100;
    [SerializeField]
    protected int maxHealthEnemy = 20;
    [SerializeField]
    private HealthBar _healthBar;
    [SerializeField]
    private HealthBar _healthBarEnemy;
    public GameObject  Boss1;
   public GameObject Boss2;
    public GameObject RoundScreen1;
    public GameObject RoundScreen2;
    public GameObject WinScreen1;
    public GameObject PlayerLooseScreen1;
    public GameObject PlayerPrepare1;
    public GameObject PlayerTeam1;
    public GameObject PlayerTeam2;
    public GameObject PlayerTeam3;
    public GameObject enemyTeam1;
    public GameObject enemyTeam2;
    public GameObject enemyTeam3;
    //----------HP-------
    [SerializeField]
    protected int enemyDeaths = 0;
    public Transform transformPoint;

    public GameObject LvlMusic;
    public GameObject WinMusic;

    void Start()
    {
        enemyDeaths = 0;
        LvlMusic.SetActive(true);
        WinMusic.SetActive(false);
        PlayerPrepare1.SetActive(true);
        BattleButtonCommon1.SetActive(false);
        BattleButtonRare1.SetActive(false);
        scoreCommonHero = 2;
        UpdateScore();
        _healthBar.SetHealthValue(Health, maxHealth);
        _healthBarEnemy.SetHealthValue(HealthEnemy, maxHealthEnemy);
        RoundScreen1.SetActive(false);
        RoundScreen2.SetActive(false);
        WinScreen1.SetActive(false);
        Boss1.SetActive(true);
        Boss2.SetActive(false);
        PlayerLooseScreen1.SetActive(false);
        Debug.Log("Подготовка к бою");
        Time.timeScale = 1;
        

    }

    private void Update()
    {
        if(CommonArmy ==2)
        {
            PlayerTeam1.SetActive(true);
            BattleButtonCommon1.SetActive(true);
            BattleButtonRare1.SetActive(false);
            Debug.Log("Обычная битва активированна!");

        }

        if (RareArmy >= 1)
        {
            PlayerTeam1.SetActive(false);
            PlayerTeam2.SetActive(true);
            BattleButtonRare1.SetActive(true);
            BattleButtonCommon1.SetActive(false);
            Debug.Log("Редкая битва активированна!");

        }
        if (EpicArmy >= 1)
        {
            PlayerTeam1.SetActive(false);
            PlayerTeam2.SetActive(false);
            PlayerTeam3.SetActive(true);
            BattleButtonEpic1.SetActive(true);
            BattleButtonCommon1.SetActive(false);
            Debug.Log("Редкая битва активированна!");

        }
        if (enemyDeaths == 2)
        {
            RoundScreen1.SetActive(true);
            Debug.Log("Первый раунд");
            Time.timeScale = 0;
           AudioListener.pause = true;
            enemyTeam1.SetActive(false);
        }
        if (enemyDeaths == 5)
        {
            RoundScreen2.SetActive(true);
            Debug.Log("Второй раунд");
            Time.timeScale = 0;
            AudioListener.pause = true;
            enemyTeam2.SetActive(false);
        }
        if (enemyDeaths == 8)
        {
            WinScreen1.SetActive(true);
            Debug.Log("Победа над Боссом!");
            Time.timeScale = 0;
            WinMusic.SetActive(true);
            LvlMusic.SetActive(false);
            enemyTeam3.SetActive(false);
        }
    }
   
    void UpdateScore()
    {
        CommonHeroText.text = ": " + scoreCommonHero;
        RareHeroText.text = ": " + scoreRareHero;
        EpicHeroText.text = ": " + scoreEpicHero;

    }
    public void CloseRound1()
    {
        enemyDeaths = 3;
        RoundScreen1.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        enemyTeam2.SetActive(true);
        PlayerTeam1.transform.position =  transformPoint.position;


    }
    public void CloseRound2()
    {
        enemyDeaths = 6;
        RoundScreen2.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        enemyTeam3.SetActive(true);
        PlayerTeam1.transform.position = transformPoint.position;
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
    public void AddEpicHeroes(int newEpicValueHero)
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
        _commonHeroCard3.SetActive(true);
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

    //---------Battler-----------
    public void DamagePlayerHP(int newHPValuePlayer)
    {
        Health -= newHPValuePlayer;
        _healthBar.SetHealthValue(Health, maxHealth);
        Debug.Log("Игрок получил урон:" + newHPValuePlayer);
       
        if (Health <= 0)
        {
            PlayerLooseScreen1.SetActive(false);
            Debug.Log(" Игрок проиграл!");
            Time.timeScale = 0;
            AudioListener.pause = true;

        }
        
    }

    public void DeathCount(int newHPValueDeaths)
    {
        enemyDeaths = newHPValueDeaths;
        Debug.Log("Сдох враг +1");

        

    }

    public void DamageEnemyHP(int newHPValueEnemy)
    {
        HealthEnemy -= newHPValueEnemy;
        _healthBarEnemy.SetHealthValue(HealthEnemy, maxHealthEnemy);
        Debug.Log("Босс получил урон:" + newHPValueEnemy);

        if (HealthEnemy <= 0)
        {
            HealthEnemy = 0;
            Boss1.SetActive(false);
            Boss2.SetActive(true);
            WinScreen1.SetActive(true);
            Debug.Log("Враг проиграл!");
            Time.timeScale = 0;
            WinMusic.SetActive(true);
            LvlMusic.SetActive(false);

        }

    }

    //---------EndBattler----------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CommonHero")
        {
            GainCommon1();
            scoreCommonHero -= 1;
            CommonArmy += 1;
            Debug.Log("Получен 1-й обычный герой");
            UpdateScore();
        }

        if (collision.gameObject.tag == "CommonHero1")
        {
            GainCommon2();
            scoreCommonHero -= 1;
            CommonArmy += 1;
            Debug.Log("Получен 2-й обычный герой");
            UpdateScore();
        }

        if (collision.gameObject.tag == "CommonHero2")
        {
            GainCommon3();
            scoreCommonHero -= 1;
            CommonArmy += 1;
            Debug.Log("Получен 3-й обычный герой");
            UpdateScore();
        }

        if (collision.gameObject.tag == "RareHero")
        {
            GainRare1();
            scoreRareHero += 1;
            scoreCommonHero -= 2;
            RareArmy += 1;
            Debug.Log("Получен 1 редкий герой");
            UpdateScore();

        }

        if (collision.gameObject.tag == "EpicHero")
        {
            GainEpic1();

            Debug.Log("Получен 1 эпический герой");

        }

    }
}
