using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager
{
    public static PrefabDatabase prefab_database;

    private static PersistentData buildDataFromScene()
    {

        SavedCore[] savedObjects = GameObject.FindObjectsOfType<SavedCore>();
        PersistentData[] savedData = new PersistentData[savedObjects.Length];
        for (int i = 0; i < savedObjects.Length; i++)
        {
            savedData[i] = savedObjects[i].createData();
        }

        MultiData result = new MultiData();
        result.setData(savedData);
        return result;
    }

    public static void saveScene(string filename)
    {

        string path = Application.persistentDataPath + "/" + filename + ".bin";

        PersistentData data = buildDataFromScene();

        TimeData timeData = new TimeData();
        WorldGenData worldData = new WorldGenData();

        timeData.saveData(null);
        worldData.saveData(null);

        data.addData(timeData);

        data.addData(worldData);

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Create(path);

        formatter.Serialize(saveFile, data);

        saveFile.Close();
    }

    public static void loadScene(string filename)
    {
        prefab_database = Resources.Load<PrefabDatabase>("PrefabDatabase");

        string path = Application.persistentDataPath + "/" + filename + ".bin";

        BinaryFormatter formatter = new BinaryFormatter();


        FileStream saveFile = File.Open(path, FileMode.Open);

        

        PersistentData loadData = (PersistentData)formatter.Deserialize(saveFile);

        loadData.loadData(null);

        saveFile.Close();
    }

}
