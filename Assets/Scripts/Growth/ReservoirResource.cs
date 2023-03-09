using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservoirResource : GrowthResource
{
    private float currentAmount;
    [SerializeField]
    private float maxAmount;


    public override void Gain(float amount)
    {
        currentAmount += amount;
        if (currentAmount > maxAmount)
        {
            currentAmount = maxAmount;
        }
    }

    public override string GetDisplayString()
    {
        return "" + Mathf.RoundToInt(currentAmount) + '\n' + Mathf.RoundToInt(maxAmount);
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
            currentAmount += -amount;
            return true;
        }
        return false;
    }
}
