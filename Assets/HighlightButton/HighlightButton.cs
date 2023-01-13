using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightButton : MonoBehaviour
{
    public void zoom(bool enter)
    {
        Vector3 scale;
        if (enter) scale = new Vector3(1.2f, 1.2f, 1f);
        else scale = new Vector3(1f, 1f, 1f);
        gameObject.GetComponent<RectTransform>().localScale = scale;
    }

}
