using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightBlocker : MonoBehaviour
{
    public float radius;
    public float intensity;

    public float getValue(Transform other)
    {
        if (other.gameObject == gameObject)
        {
            return 1;
        }
        float distance = (other.position - transform.position).magnitude;
        float value = 1 - (distance / radius);
        value = Mathf.Clamp(value, 0 ,1);
        return value * radius;
    }
}
