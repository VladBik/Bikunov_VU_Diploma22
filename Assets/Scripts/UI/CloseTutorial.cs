using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorial : MonoBehaviour
{
    public GameObject TutorialMerge1;
    public GameObject MergeItems1;
    //public GameObject ButtonBattle1;

    void Start()
    {
        TutorialMerge1.SetActive(true);
        MergeItems1.SetActive(false);
       // ButtonBattle1.SetActive(false);
    }

    public void CloseTutor()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        TutorialMerge1.SetActive(false);
        MergeItems1.SetActive(true);
        //ButtonBattle1.SetActive(true);
    }
}
