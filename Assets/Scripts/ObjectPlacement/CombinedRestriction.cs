using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Placement Restrictions/Combined Restriction")]
public class CombinedRestriction : PlacementRestriction
{
    public PlacementRestriction[] combinedRestrictions;
    public override bool validPlacement(Vector3 position)
    {
        foreach (PlacementRestriction restriction in combinedRestrictions)
        {
            if (!restriction.validPlacement(position))
            {
                return false;
            }
        }
        return true;
    }
}
