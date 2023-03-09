using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Placement Restrictions/Proximity Restriction")]
public class ProximityRestriction : PlacementRestriction
{
    public override bool validPlacement(Vector3 position)
    {
        PlacementBlocker[] blockingObjects = FindObjectsOfType<PlacementBlocker>();

        foreach (PlacementBlocker blocker in blockingObjects)
        {
            if ((position-blocker.getBlockerCenter()).magnitude < blocker.getBlockerRadius()) {
                return false;
            }
        }


        return true;
    }
}
