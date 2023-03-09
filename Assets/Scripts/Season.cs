using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Season")]
public class Season : ScriptableObject
{
    public string title;

    public bool useSnow;
    public float precipitationMinimum;
    public float precipitationMaximum;


    public float getPrecipitationValue(float mapValue)
    {
        //min value
        float result = Mathf.Clamp(mapValue, precipitationMinimum, precipitationMaximum);

        result += -precipitationMinimum;

        float precipitationDelta = precipitationMaximum - precipitationMinimum;
        result = result / precipitationDelta;

        return result;
    }
}
