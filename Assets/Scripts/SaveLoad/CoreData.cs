using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoreData : PersistentData
{
    public override bool load(GameObject gameObject)
    {
        Debug.Log(id);
        return true;

    }

    public int id;

    public override bool save(GameObject gameObject)
    {
        SavedObject saved = gameObject.GetComponent<SavedObject>();

        if (saved == null)
        {
            return false;
        }

        id = saved.id;
        return true;
    }
}
