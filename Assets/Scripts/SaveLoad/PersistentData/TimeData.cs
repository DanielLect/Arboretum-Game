using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimeData : PersistentData
{
    public float timePassed;
    protected override GameObject load(GameObject gameObject)
    {
        TimeManager.Get().setTime(timePassed);
        return null;
    }

    protected override GameObject save(GameObject gameObject)
    {
        timePassed = TimeManager.Get().getTime();
        return null;
    }
}
