using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{

    #region Singleton
    public static WeatherManager Get()
    {
        return instance;
    }
    static WeatherManager instance;
    void Start()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    private ParticleController rainController;
    [SerializeField]
    private ParticleController snowContoller;

    public float intensity;
    // Start is called before the first frame update


    // Update is called once per frame

    public float perlin_scale = 100;
    public float perlin_seed = 10;
    void Update()
    {
        float precipitationValue = SeasonManager.Get().getCurrentSeason().getPrecipitationValue(getMapValue());
        if (SeasonManager.Get().getCurrentSeason().useSnow)
        {
            snowContoller.setIntensity(precipitationValue);
            rainController.setIntensity(0);
        } else
        {
            rainController.setIntensity(precipitationValue);
            snowContoller.setIntensity(0);
        }
    }

    public float getPrecipitationValue()
    {
        return SeasonManager.Get().getCurrentSeason().getPrecipitationValue(getMapValue());
    }


    float getMapValue()
    {
        float time = TimeManager.Get().getTime();
        float result = Mathf.PerlinNoise(perlin_seed + time / perlin_scale, 0);
        
        return result;
    }


}
