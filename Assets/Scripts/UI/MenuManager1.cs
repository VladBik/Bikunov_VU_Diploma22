using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager1 : MonoBehaviour
{
    public GameObject Window1; 
    public GameObject Window2;
    public GameObject Window3;
    public GameObject Window4;

    public GameObject pWin1;
    public GameObject pWin2;
    public GameObject globalWin;

    public GameObject playerTeam1;

    public GameObject enemyTeam1;
    public GameObject enemyTeam2;
    public GameObject enemyTeam3;
    public GameObject PlayerPrepareRound;
    public GameObject closeMerge;
    public GameObject StartCommon;
    public GameObject StartRare;

    private void Start()
    {
        AudioListener.pause = true;
        Time.timeScale = 0f;
        PlayerPrepareRound.SetActive(true);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Play1()
    {
        SceneManager.LoadScene(1);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;

    }

    public void RestoreTime1()
    {
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;

    }
    public void Play2()
    {
        SceneManager.LoadScene(2);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;

    }
    public void Play3()
    {
        SceneManager.LoadScene(3);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;

    }

    public void StartcommonRound()
    {
         closeMerge.SetActive(false); 
    StartCommon.SetActive(true);
        Time.timeScale = 0f;
    }
    public void StartRound1()
    {
        playerTeam1.SetActive(true);
        enemyTeam1.SetActive(true);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        PlayerPrepareRound.SetActive(false);
    }
    public void StartRound2()
    {
        enemyTeam1.SetActive(false);
        enemyTeam2.SetActive(true);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        pWin1.SetActive(false);
    }
    public void StartRound3()
    {
        enemyTeam1.SetActive(false);
        enemyTeam2.SetActive(false);
        enemyTeam3.SetActive(true);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        pWin2.SetActive(false);
    }


    public void OpenWindow1()
    {
        Window1.SetActive(true);
    }
    public void CloseWindow1()
    {
        Window1.SetActive(false);
    }

    public void OpenWindow2()
    {
        Window2.SetActive(true);
    }
    public void CloseWindow2()
    {
        Window2.SetActive(false);
    }
    public void OpenWindow3()
    {
        Window3.SetActive(true);
    }
    public void CloseWindow3()
    {
        Window3.SetActive(false);
    }
    public void OpenWindow4()
    {
        Window4.SetActive(true);
    }
    public void CloseWindow4()
    {
        Window4.SetActive(false);
    }
    public void Play4()
    {
        SceneManager.LoadScene(4);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }

    public void Play5()
    {
        SceneManager.LoadScene(5);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
    public void Play6()
    {
        SceneManager.LoadScene(6);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }

    public void Play7()
    {
        SceneManager.LoadScene(7);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }

    public void Play8()
    {
        SceneManager.LoadScene(8);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
    public void PlayChooseHeroes()
    {
        SceneManager.LoadScene(6);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }


    //public void PlaySecret()
    // {
    //  SceneManager.LoadScene(2);
    // gameObject.SetActive(true);
    //  AudioListener.pause = false;
    // Time.timeScale = 1f;
    // }

    public void Exit()
    {
        Application.Quit();

    }

    

}
