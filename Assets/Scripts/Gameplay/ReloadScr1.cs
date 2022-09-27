using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ReloadScr1 : MonoBehaviour
{
    [SerializeField]
    private Slider _sliderR;
    [SerializeField]
    private Vector3 _offset;

    private void Update()
    {
        _sliderR.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }

    public void SetSliderValueR(int ReloadFire, int nextFire)
    {
        _sliderR.gameObject.SetActive(ReloadFire < nextFire);
        _sliderR.value = ReloadFire;
        _sliderR.maxValue = nextFire;
    }
}
