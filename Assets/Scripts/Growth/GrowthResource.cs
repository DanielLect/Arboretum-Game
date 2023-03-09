using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GrowthResource : MonoBehaviour
{
    public ResourceType resourceType;
    public abstract void Gain(float amount);

    public abstract bool Has(float amount);
    public abstract bool Use(float amount);

    public abstract string GetDisplayString();
}
