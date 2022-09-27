using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCardCommon : MonoBehaviour
{
    public GameObject _hero1Common;
    public GameObject _hero1CommonArmySlot1;
    public void FixedUpdate()
    {

        Armygain1();
    }
   
    public void Armygain1()
    {
        _hero1CommonArmySlot1.SetActive(true);
        Destroy(_hero1Common, 2.5f);


    }
}
