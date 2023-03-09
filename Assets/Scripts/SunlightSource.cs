
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightSource : MonoBehaviour
{
    public float sunlightGain;
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
            if (resource.resourceType == ResourceType.Sunlight)
            {
                resource.Gain(calculateSunlightGain(resource));
            }
        }
    }

    float calculateSunlightGain(GrowthResource resource)
    {
        return sunlightGain * SunManager.Get().dayValue;
    }
}
