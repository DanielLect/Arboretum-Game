
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightSource : MonoBehaviour
{
    public float sunlightGain;
    GrowthCollection growthCollection;

    SunlightBlocker[] sunBlockers;
    // Start is called before the first frame update
    void Start()
    {
        growthCollection = GetComponent<GrowthCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        sunBlockers = FindObjectsOfType<SunlightBlocker>();

        foreach (GrowthResource resource in growthCollection.getAllSceneResources())
        {
            if (resource.resourceType == ResourceType.Sunlight)
            {
                resource.Gain(calculateSunlightGain(resource));
            }
        }
    }

    float calculateSunlightGain(GrowthResource resource)
    {
        float sunBlock = 0;
        for (int i = 0; i < sunBlockers.Length; i++)
        {
            float tempSunBlock = sunBlockers[i].getValue(resource.transform);
            if (tempSunBlock > sunBlock)
            {
                sunBlock = tempSunBlock;
            }
        }

        float rainValue = 1-WeatherManager.Get().getPrecipitationValue();

        float result = rainValue * sunlightGain * SunManager.Get().dayValue - sunBlock;
        if (result < 0)
        {
            result = 0;
        }
        return result;
    }
}
