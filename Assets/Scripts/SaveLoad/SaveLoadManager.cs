using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager
{

    PersistentData data;
    private static PersistentData buildDataFromScene()
    {

    }

    public static void saveScene(string filename)
    {

        string path = Application.persistentDataPath + "/" + filename + ".bin";

        PersistentData data = buildDataFromScene();

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Create(path);

        formatter.Serialize(saveFile, data);

        saveFile.Close();
    }

    public static void loadScene(string filename)
    {
        string path = Application.persistentDataPath + "/" + filename + ".bin";

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Open(path, FileMode.Open);

        PersistentData loadData = (PersistentData)formatter.Deserialize(saveFile);

        loadData.loadData();

        saveFile.Close();
    }

}
