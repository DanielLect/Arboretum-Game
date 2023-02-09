
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PrefabDatabase")]
public class PrefabDatabase : ScriptableObject
{

    public SavedObject[] templates;


    public SavedObject getFromDatabase(int id)
    {
        return templates[id];
    }
}
