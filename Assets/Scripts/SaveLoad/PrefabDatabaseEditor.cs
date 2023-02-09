using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PrefabDatabase))]
public class PrefabDatabaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Resync Database"))
        {
            ResyncDatabase();
        }
        DrawDefaultInspector();



        //serializedObject.ApplyModifiedProperties();
    }
    void ResyncDatabase()
    {
        SavedObject[] templates = Resources.LoadAll<SavedObject>("Prefabs");

        PrefabDatabase database = (PrefabDatabase)target;
        SerializedObject serializedObject = new SerializedObject(database);

        serializedObject.Update();

        SerializedProperty serializedArray = serializedObject.FindProperty("templates");

        serializedArray.ClearArray();

        serializedArray.arraySize = templates.Length;
        for (int i = 0; i < templates.Length; i++)
        {
            serializedArray.GetArrayElementAtIndex(i).objectReferenceValue = templates[i];
        }

        serializedObject.ApplyModifiedProperties();


        for (int i = 0; i < templates.Length; i++)
        {
            ResyncSavedObject(templates[i], i);
        }

        //EditorGUILayout.PropertyField(myTextArea, true);
        //serializedObject.ApplyModifiedProperties();
    }

    void ResyncSavedObject(SavedObject saved, int index)
    {

        SerializedObject serializedObject = new SerializedObject(saved);

        serializedObject.Update();

        SerializedProperty serializedId = serializedObject.FindProperty("id");
        serializedId.intValue = index;

        serializedObject.ApplyModifiedProperties();

    }
}
