
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PrefabDatabase")]
public class PrefabDatabase : ScriptableObject
{

    public SavedCore[] templates;


    public SavedCore getFromDatabase(int id)
    {
        return templates[id];
    }
}
