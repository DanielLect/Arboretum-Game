using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultiData : PersistentData
{

    PersistentData[] loadedData;

    public void setData(PersistentData[] input)
    {
        loadedData = input;

    }

    protected override GameObject load(GameObject gameObject)
    {
        for (int i = 0; i < loadedData.Length; i++)
        {
            loadedData[i].loadData(gameObject);
        }
        return gameObject;
    }

    protected override GameObject save(GameObject gameObject)
    {
        for (int i = 0; i < loadedData.Length; i++)
        {
            loadedData[i].saveData(gameObject);
        }
        return gameObject;
    }
}
