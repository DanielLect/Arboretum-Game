using UnityEngine;

public class GrowthStage : MonoBehaviour
{
    //usage per "tick" for each resource
    public float sunlight_use_per_second;
    public float water_use_per_second;

    float currentGrowth = 0;

    //how many "ticks" to grow
    public float maxGrowthSecond;

    public void Grow(Growth growth)
    {
        bool sunlightMet = growth.getResource(ResourceType.Sunlight).Has(sunlight_use_per_second);
        bool waterMet = growth.getResource(ResourceType.Water).Has(water_use_per_second);

        if (sunlightMet && waterMet)
        {
            float timeDelta = Time.deltaTime * TimeManager.Get().timeScale;

            growth.getResource(ResourceType.Sunlight).Use(sunlight_use_per_second*timeDelta);
            growth.getResource(ResourceType.Water).Use(water_use_per_second*timeDelta);

            currentGrowth += timeDelta;
            
        }

    }

    public string getWaterUseString()
    {
        return ">" + Mathf.RoundToInt(water_use_per_second);
    }
    public string getSunlightUseString()
    {
        return ">" + Mathf.RoundToInt(sunlight_use_per_second);
    }

    public float getPercentage()
    {
        return Mathf.Clamp(currentGrowth / maxGrowthSecond, 0, 1);
    }

    public bool Advance()
    {
        if (currentGrowth >= maxGrowthSecond)
        {
            return true;
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
