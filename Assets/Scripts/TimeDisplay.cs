using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = offset + 24f * TimeManager.Get().currentTime;
        while (time > 24)
        {
            time += -24;
        }
        while (time < 0)
        {
            time += 24;
        }

        int hours = (int)time;
        int minutes = (int)((time - hours) * 60f);

        string ampm = "AM";

        if (hours >= 12)
        {
            ampm = "PM";
        }
        if (hours > 12)
        {
            hours += -12;
        }
        if (hours == 0)
        {
            hours = 12;
        }
             
        string display = "";
        if (hours < 10)
        {
            display += "0";
        }
        display += hours + ":";

        if (minutes < 10)
        {
            display += "0";
        }
        display += minutes + ampm;

        text.text = display;
    }
}
