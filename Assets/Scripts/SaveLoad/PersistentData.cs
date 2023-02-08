using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PersistentData
{
    PersistentData link;

    public abstract bool load(GameObject gameObject);
    public abstract bool save(GameObject gameObject);

    public void addData(PersistentData other)
    {
        if (link == null)
        {
            link = other;
            return;
        }
        link.addData(other);
    }

    public void saveData(GameObject gameObject)
    {
        if (save(gameObject))
        {
            if (link != null)
            {
                link.saveData(gameObject);
            }
        }
    }
    public void loadData()
    {
        if (load(null))
        {
            if (link != null)
            {
                link.loadData();
            }
        }
    }



}
