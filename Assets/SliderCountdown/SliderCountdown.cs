using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SliderCountdown : MonoBehaviour
{
   
    public Slider slider;
    public float maxTime;
    private float time;
    private bool count = false;

    
    void Start()
    {
        slider.maxValue = maxTime;
        time = maxTime;
        slider.value = slider.maxValue;
        //text.text = time.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown("t")) count = !count;
        if (count) startCount();
    }

    public void startCount()
    {
        if (time > 0f)
        {
            time -= 1 * Time.deltaTime;
            //text.text = Mathf.FloorToInt(time).ToString();
            slider.value = time;
            changeColor(time);
        }
        else
        {
            time = 0;
            //text.text = time.ToString();
        }

    }

    public void changeColor(float time)
    {
        if (time >= 8)
        {
            slider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(0, 255, 0);
        }

        if (time < 8 && time >= 5)
        {
            slider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 0);
        }

        if (time < 5)
        {
            slider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255, 0, 0);
        }
    }
}