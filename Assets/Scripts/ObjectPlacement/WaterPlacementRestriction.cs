using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Placement Restrictions/Water Restriction")]
public class WaterPlacementRestriction : PlacementRestriction
{
    public float waterHeight;
    public override bool validPlacement(Vector3 position)
    {
        return (position.y > waterHeight);
    }
}
