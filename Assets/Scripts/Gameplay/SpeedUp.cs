using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedUp : MonoBehaviour
{
    public Text SpeedUpText;
    [SerializeField]
    private int _timecount;
    private void FixedUpdate()
    {
        if (Time.timeScale <= 0)
        {
            Time.timeScale = 1;
        }
        if (_timecount <= 0)
        {
            _timecount = 1;
        }
    }
    private void Start()
    {
        UpdateScore();
        _timecount = 0;
    }
    void UpdateScore()
    {
        SpeedUpText.text = "X " + _timecount;
    }
    public void SpeedUp2()
    {
        Time.timeScale += 1;
        _timecount += 1;

        if (Time.timeScale >= 4)
        {
            Time.timeScale = 4;
        }
        if (_timecount >= 4)
        {
            _timecount = 4;
        }
        UpdateScore();
    }

    public void SpeedUp1()
    {
        Time.timeScale -= 1;
        _timecount -= 1;
        if (Time.timeScale <= 0)
        {
            Time.timeScale = 1;
        }
        if (_timecount <= 0)
        {
            _timecount = 1;
        }
        UpdateScore();
    }

    
}