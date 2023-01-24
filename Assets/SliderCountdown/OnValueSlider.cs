using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OnValueSlider : MonoBehaviour
{
    public Text text;
    
    public void OnSliderChanged(float value)
    {
        text.text = value.ToString();
    }
}
