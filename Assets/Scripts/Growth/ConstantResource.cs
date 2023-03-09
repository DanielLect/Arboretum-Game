using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantResource : GrowthResource
{
    private float currentAmount = 0;

    public override void Gain(float amount)
    {
        currentAmount = amount;
    }

    public override string GetDisplayString()
    {
        return "" + Mathf.RoundToInt(currentAmount);
    }

    public override bool Has(float amount)
    {
        if (currentAmount >= amount)
        {
            return true;
        }
        return false;
    }

    public override bool Use(float amount)
    {
        if (currentAmount >= amount)
        {
            return true;
        }
        return false;
    }

}
