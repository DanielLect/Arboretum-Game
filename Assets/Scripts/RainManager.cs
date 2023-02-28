using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    public float maxIntensity;
    public float intensity;
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var a = particleSystem.emission;

        a.rateOverTime = maxIntensity*intensity;
    }
}
