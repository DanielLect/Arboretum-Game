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
        PersistentData data1 = new CoreData();
        data1.addData(new CoreData());
        data1.addData(new CoreData());
        data1.addData(new CoreData());

        data1.saveData(gameObject);

        //save(data1);
        load();


    }

    public void save(PersistentData data)
    {

        string path = Application.persistentDataPath + "/data.bin";

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Create(path);

        formatter.Serialize(saveFile, data);

        saveFile.Close();
    }

    public void load()
    {
        string path = Application.persistentDataPath + "/data.bin";

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Open(path, FileMode.Open);

        PersistentData loadData = (PersistentData)formatter.Deserialize(saveFile);

        loadData.loadData();

        saveFile.Close();
    }

}
