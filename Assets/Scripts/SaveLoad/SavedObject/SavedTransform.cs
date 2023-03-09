using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedTransform : SavedObject
{
    public override PersistentData createData()
    {
        TransformData data = new TransformData();
        return data;
    }

}
