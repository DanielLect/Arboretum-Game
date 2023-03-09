using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Map : MonoBehaviour
{
    public abstract float calculate(float x, float z, float seed);
}
