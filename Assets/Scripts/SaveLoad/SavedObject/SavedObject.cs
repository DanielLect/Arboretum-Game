using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SavedObject : MonoBehaviour
{
    public abstract PersistentData createData();
}
