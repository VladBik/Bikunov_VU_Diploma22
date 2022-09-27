using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOneWind : MonoBehaviour
{
    public GameObject Window1;
    public GameObject Window2;
    public GameObject Player1;
    public void OpenWindow1()
    {
        Window1.SetActive(true);
        Window2.SetActive(false);
        Player1.SetActive(false);
    }
    public void CloseWindow1()
    {
        Window1.SetActive(false);
    }
}
