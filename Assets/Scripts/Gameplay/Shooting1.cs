using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shooting1 : MonoBehaviour
{
    public float fireRate = 1.7f;
    public float nextFire = 1.0f;
   
     

    public GameObject Bullet;
    public Transform firePoint;
    public int directionInput;


     // ������� ���������� ���������, ���/���� � �����������
    public float timeout = 2; // ����� ������ �������� � ��������

    // �������� �����

    // ����������� � ������������ ������������� ��������� �����
    public Color maxColor = Color.white;
    public Color halfColor = Color.yellow;
    public Color minColor = Color.red;

    public Slider slider; // ������� UI

    // ����� ����������
    

    public float reloadTime = 2.0f; // ����� ����������� � ��������
    // ��������� ���������� �������� ��������

    private float curTime;
    private Image sliderColor;
    private float curReloadTime;


    void Awake()
    {
        sliderColor = slider.fillRect.GetComponentInChildren<Image>();
    }

    private void Start()
    {
        sliderColor.color = maxColor;
        slider.minValue = 0;
        slider.maxValue = 2;
        slider.value = 2;
       
    }

    
    private void FixedUpdate()
    {
        if ( Input.GetButtonDown("Fire1"))
        {
            Shoot();
            

        }
        curTime += Time.deltaTime;

        if (curTime > timeout)
        {
            curTime = 0;
            slider.value = 0;

        }
        else if (curTime != 0)
        {
            // ��������� ����� � �������� �������� �� 0 �� 100% � ������� �� 100
            slider.value = 2 - (curTime / timeout) * 2;
        }

        else if (nextFire <= 1)
        {
            curReloadTime += Time.deltaTime;
            if (curReloadTime > reloadTime)
            {
                curReloadTime = 0;


                slider.value = 2;

            }
        }
    }
		
		
    
    public void Shoot()
        //public void Shoot(int InputAxis)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //slider.value = 2;


            Instantiate(Bullet, firePoint.position, Quaternion.identity);
        }
        //directionInput = InputAxis;
       

    }
    
   
}