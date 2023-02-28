using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PersistentData
{
    PersistentData link;

    protected abstract GameObject load(GameObject gameObject);
    protected abstract GameObject save(GameObject gameObject);

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
        GameObject result = save(gameObject);

        if (link != null)
        {
            link.saveData(result);
        }
    }
    public void loadData(GameObject gameObject)
    {
        GameObject result = load(gameObject);

        if (link != null)
        {
            link.loadData(result);
        }
    }



}
