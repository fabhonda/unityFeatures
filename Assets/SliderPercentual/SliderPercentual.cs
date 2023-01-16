using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderPercentual : MonoBehaviour
{

    public int totalMatches;
    public int victories;
    public Slider slider;
    public List<Text> texts;


    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            victories = (int)Random.Range(1, 100);
            totalMatches = (int)Random.Range(100, 200);
            slider.value = Mathf.FloorToInt((victories / (float)totalMatches) * 100);
            texts[0].text = totalMatches.ToString(); texts[1].text = victories.ToString();
            texts[2].text = slider.value.ToString() + "%";
        }
    }
}
