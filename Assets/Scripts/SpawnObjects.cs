using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("������ ������������ �������")]
    public GameObject Obj;
    [Header("����� �� �������� �������")]
    public float GreateSec = 3;
    [Header("����� �� ����������� �������")]
    public float DestroySec = 3;

    private GameObject NewObj;

    void Awake()
    {
        StartCoroutine(TimerGreateObject(GreateSec));
    }

    private IEnumerator TimerGreateObject(float sec)
    {
        yield return new WaitForSeconds(sec);
        GreateObject();
    }

    private void GreateObject()
    {
        NewObj = Instantiate(Obj, transform.position, Quaternion.Euler(0, 0, 0));
        
        Destroy(NewObj, DestroySec);
        StartCoroutine(TimerGreateObject(GreateSec));
    }
}
