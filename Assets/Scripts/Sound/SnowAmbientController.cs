using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowAmbientController : MonoBehaviour
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
            float volume = WeatherManager.Get().getPrecipitationValue();
            return volume;
        }
        return 0;

    }

    // Update is called once per frame
    void Update()
    {
        ambientPlayer.volume = getVolume();
    }
}
