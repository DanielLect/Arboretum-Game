using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : MonoBehaviour
{
    public float waterLevel;

    public float maxDistance;

    public float staticWaterGain;

    public float rainGain;

    GrowthCollection growthCollection;
    // Start is called before the first frame update
    void Start()
    {
        growthCollection = GetComponent<GrowthCollection>();
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GrowthResource resource in growthCollection.getAllSceneResources())
        {
            if (resource.resourceType == ResourceType.Water)
            {
                applyRainWater(resource);
                applyHeightWater(resource);
            }
        }
    }

    void applyHeightWater(GrowthResource resource)
    {
        float heightDif = resource.transform.position.y - waterLevel;
        if (heightDif < 0)
        {
            heightDif = 0;
        }

        float factor = 1.0f - (heightDif / maxDistance);
        factor = Mathf.Clamp(factor, 0, 1);


        resource.Gain(factor*staticWaterGain * Time.deltaTime * TimeManager.Get().timeScale);


    }

    void applyRainWater(GrowthResource resource)
    {
        if (SeasonManager.Get().getCurrentSeason().useSnow)
        {
            return;
        }
        float factor = WeatherManager.Get().getPrecipitationValue();

        resource.Gain(factor * rainGain * Time.deltaTime * TimeManager.Get().timeScale);
    }
}
