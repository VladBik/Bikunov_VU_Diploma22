using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Versions : MonoBehaviour
{
    
    public static int versionNumber;
    [SerializeField]
    private Text versionNumberText;
    void Start()
    {
        versionNumberText = GetComponent<Text>();
        versionNumber = 23;
    }

    // Update is called once per frame
    void Update()
    {
        versionNumberText.text = "V.1." + versionNumber;
    }
}
