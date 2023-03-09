using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherDisplay : MonoBehaviour
{
    public Sprite sunshineIcon;
    public Sprite snowIcon;
    public Sprite rainIcon;
    public Sprite nightIcon;

    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sunshineIcon;
        if (SunManager.Get().nightValue > 0)
        {
            image.sprite = nightIcon;
        }
        if (WeatherManager.Get().getPrecipitationValue() > 0)
        {
            image.sprite = rainIcon;
            if (SeasonManager.Get().getCurrentSeason().useSnow)
            {
                image.sprite = snowIcon;
            }
        }
    }
}
