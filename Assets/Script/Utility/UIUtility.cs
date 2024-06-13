using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

static public class UIUtility
{
    static readonly string _imagePath = "Image/";

    static public void SetText(TextMeshProUGUI text, string str)
    {
        text.text = str;
    }

    static public void SetImage( Image img, string res )
    {
        Sprite sprite = Resources.Load<Sprite>(_imagePath + res);
        if( null == sprite )
        {
            Debug.Log($"Image setting is not Available {res}");
            return;
        }

        img.sprite = sprite;
    }
}
