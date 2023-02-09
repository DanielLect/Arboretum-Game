using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SceneObjectData : PersistentData
{
    PersistentData[] objectData;
    public override bool load(GameObject gameObject)
    {
        return false;
    }

    public override bool save(GameObject gameObject)
    {
        SavedObject[] dataIn = GameObject.FindObjectsOfType<SavedObject>();
        objectData = new PersistentData[dataIn.Length];

        for (int i = 0; i < dataIn.Length; i++)
        {
            objectData[i] = dataIn[i].createData();
            objectData[i].save(null);
        }

        return true;
    }

}
