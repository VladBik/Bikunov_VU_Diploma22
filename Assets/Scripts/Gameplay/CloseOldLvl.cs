using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOldLvl : MonoBehaviour
{
    public GameObject lvl1;
    public GameObject lvl2;
    public void Close1()
    {
        lvl2.SetActive(true);
        lvl1.SetActive(false);
       
        Time.timeScale = 1;
    }
}
