using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldGenData : PersistentData
{
    float seed;

    protected override GameObject load(GameObject gameObject)
    {
        WorldGenManager.Get().seed = seed;
        WorldGenManager.Get().creator.createTerrain(seed);
        return gameObject;
    }

    protected override GameObject save(GameObject gameObject)
    {
        seed = WorldGenManager.Get().seed;
        Debug.Log(seed);
        return gameObject;
    }


}
