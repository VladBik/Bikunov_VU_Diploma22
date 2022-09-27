using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRare : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
            Instantiate(Resources.Load("Derevo_Object"), transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
