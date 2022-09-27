using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTest : MonoBehaviour
{
    public static int _colorsNumber;
    
    private Text colorsNumberText;
    void Start()
    {
        colorsNumberText = GetComponent<Text>();
        _colorsNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        colorsNumberText.text = ": " + _colorsNumber;
    }
}
