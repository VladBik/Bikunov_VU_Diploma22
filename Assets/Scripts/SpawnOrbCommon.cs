using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrbCommon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load("Idol1_Object"), transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
