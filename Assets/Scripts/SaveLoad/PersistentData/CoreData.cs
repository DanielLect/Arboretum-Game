using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoreData : PersistentData
{
    protected override GameObject load(GameObject gameObject)
    {
        GameObject clone = GameObject.Instantiate(SaveLoadManager.prefab_database.getFromDatabase(id).gameObject);
        return clone;

    }

    public int id;

    protected override GameObject save(GameObject gameObject)
    {
        SavedCore saved = gameObject.GetComponent<SavedCore>();

        if (saved == null)
        {
            return null;
        }

        id = saved.id;
        return gameObject;
    }
}
