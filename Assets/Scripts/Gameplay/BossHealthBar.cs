using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider _sliderEnem;
    [SerializeField]
    private Vector3 _offset;

    private void Update()
    {
        _sliderEnem.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }

    public void SetHealthValue2(int currentHealth, int maxHealth)
    {
        _sliderEnem.gameObject.SetActive(currentHealth < maxHealth);
        _sliderEnem.value = currentHealth;
        _sliderEnem.maxValue = maxHealth;
    }
}
