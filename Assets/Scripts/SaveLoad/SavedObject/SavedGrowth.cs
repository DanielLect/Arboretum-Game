using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedGrowth : SavedObject
{
    public override PersistentData createData()
    {
        GrowthData data = new GrowthData();
        return data;
    }
}
