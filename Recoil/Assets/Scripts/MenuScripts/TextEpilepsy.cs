using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEpilepsy : MonoBehaviour
{
    //float timeSwitch = 0f;
    //float nextTime = 0.1f;

    UnityEngine.UI.Text text;
    float hue = 0f;
    float sat = 1f;
    float v = 1f;

    private void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
    }
    // Update is called once per frame
    void Update()
    {
        //if (transform.parent.gameObject.activeSelf && timeSwitch <= Time.unscaledTime)
        //{
        //    timeSwitch = Time.unscaledTime + nextTime;
        //    if (text.color == Color.green)
        //    {
        //        text.color = Color.red;
        //    }
        //    else
        //    {
        //        text.color = Color.green;
        //    }

        //}

        if (transform.parent.gameObject.activeSelf)
        {
            text.color = Color.HSVToRGB(hue, sat, v);
            hue += 0.02f;
            if (hue >= 0.95f) hue = 0;
        }
    }
}
