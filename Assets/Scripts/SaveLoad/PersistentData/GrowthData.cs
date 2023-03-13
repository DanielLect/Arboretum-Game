using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GrowthData : PersistentData
{
    float waterValue;
    float percentage;
    //float age;
    //float deltaGrowth;
    protected override GameObject load(GameObject gameObject)
    {
        gameObject.GetComponent<Growth>().setPercentage(percentage);
        gameObject.GetComponent<ReservoirResource>().setCurrentAmount(waterValue);
        //gameObject.GetComponent<Growth>().age = age;
        //gameObject.GetComponent<Growth>().deltaGrowth = deltaGrowth;

        return gameObject;
    }

    protected override GameObject save(GameObject gameObject)
    {
        percentage = gameObject.GetComponent<Growth>().getPercentage();
        waterValue = gameObject.GetComponent<ReservoirResource>().getCurrentAmount();
        //age = gameObject.GetComponent<Growth>().age;
        //deltaGrowth = gameObject.GetComponent<Growth>().deltaGrowth;
        return gameObject;
    }

}
