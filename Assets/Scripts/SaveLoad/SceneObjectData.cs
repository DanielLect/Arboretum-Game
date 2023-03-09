using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SceneObjectData : PersistentData
{
    PersistentData[] objectData;
    protected override GameObject load(GameObject gameObject)
    {
        return null;
        //return false;
    }

    protected override GameObject save(GameObject gameObject)
    {
        SavedCore[] dataIn = GameObject.FindObjectsOfType<SavedCore>();
        objectData = new PersistentData[dataIn.Length];

        return null;
        /*
        for (int i = 0; i < dataIn.Length; i++)
        {
            objectData[i] = dataIn[i].createData();
            objectData[i].save(null);
        }
        */
        //return true;
    }

}
