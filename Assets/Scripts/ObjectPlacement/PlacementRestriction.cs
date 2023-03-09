using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacementRestriction : ScriptableObject
{

    //returns true if the specified position is a valid placement position for a tree
    public abstract bool validPlacement(Vector3 position);
    
}
