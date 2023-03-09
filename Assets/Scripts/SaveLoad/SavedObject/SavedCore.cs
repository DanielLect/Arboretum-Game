using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavedCore : SavedObject
{
    public int id;

    
    private void Start()
    {

    }

    public override PersistentData createData()
    {
        PersistentData data = new CoreData();

        SavedObject[] savedObjects = gameObject.GetComponents<SavedObject>();

        for (int i = 0; i < savedObjects.Length; i++)
        {
            if (savedObjects[i] != this)
            {
                data.addData(savedObjects[i].createData());
            }
        }

        data.saveData(gameObject);

        return data;

    }


}
