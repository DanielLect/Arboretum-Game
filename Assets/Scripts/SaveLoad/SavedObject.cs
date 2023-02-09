using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavedObject : MonoBehaviour
{
    public int id;

    
    private void Start()
    {

    }

    public PersistentData createData()
    {
        PersistentData data = new CoreData();

        return data;


    }


}
