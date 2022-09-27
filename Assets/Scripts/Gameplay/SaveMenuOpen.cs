using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMenuOpen : MonoBehaviour
{
    public GameObject saveMenuCanvas;
    public void SaveMenu1()
    {

        saveMenuCanvas.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        saveMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
