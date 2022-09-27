using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySimpleObject1 : MonoBehaviour
{
   [SerializeField]
    private float _destroyTime1 = 1.5f;
    void Start()
    {
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject, _destroyTime1);
    }
}
