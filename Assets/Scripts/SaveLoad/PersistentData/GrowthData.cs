using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GrowthData : PersistentData
{

    float age;
    float deltaGrowth;
    protected override GameObject load(GameObject gameObject)
    {
        gameObject.GetComponent<Growth>().age = age;
        gameObject.GetComponent<Growth>().deltaGrowth = deltaGrowth;

        return gameObject;
    }

    protected override GameObject save(GameObject gameObject)
    {
        age = gameObject.GetComponent<Growth>().age;
        deltaGrowth = gameObject.GetComponent<Growth>().deltaGrowth;
        return gameObject;
    }

}
