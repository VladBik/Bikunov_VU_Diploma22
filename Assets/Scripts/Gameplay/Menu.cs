using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play1()
    {
        SceneManager.LoadScene(4);
        gameObject.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f;

    }
}
