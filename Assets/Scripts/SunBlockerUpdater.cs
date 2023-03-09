using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBlockerUpdater : MonoBehaviour
{
    SunlightBlocker blocker;
    Growth growth;

    float finalRadius;
    float finalIntensity;
    // Start is called before the first frame update
    void Start()
    {
        blocker = GetComponent<SunlightBlocker>();
        growth = GetComponent<Growth>();

        finalRadius = blocker.radius;
        finalIntensity = blocker.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        blocker.radius = finalRadius * growth.getPercentage();
        blocker.intensity = finalIntensity * growth.getPercentage();
    }
}
