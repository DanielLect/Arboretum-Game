using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketAmbientController : MonoBehaviour
{
    AmbientSoundPlayer ambientPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ambientPlayer = GetComponent<AmbientSoundPlayer>();
    }

    float getVolume()
    {

        if (SeasonManager.Get().getCurrentSeason().useSnow)
        {
            return 0;
        }
        float result = (SunManager.Get().nightValue) * (1 - WeatherManager.Get().getPrecipitationValue());
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        ambientPlayer.volume = getVolume();
    }
}
