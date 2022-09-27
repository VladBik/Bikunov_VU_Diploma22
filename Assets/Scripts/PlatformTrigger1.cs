using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger1 : MonoBehaviour
{
    [SerializeField]
    private Behaviour _FallPlatform;
    [SerializeField]
    private Behaviour _ActivationScript;
    [SerializeField]
    private Behaviour _AnimatorOfScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _FallPlatform.enabled = true;
            _AnimatorOfScript.enabled = true;
            _ActivationScript.enabled = false;
        }

    }
        
}
