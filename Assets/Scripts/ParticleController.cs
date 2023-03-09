using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public void setIntensity(float intensity)
    {
        this.intensity = Mathf.Clamp(intensity,0,1);
    }

    [SerializeField]
    private float maxRate;
    private float intensity = 0;
    [SerializeField]
    private ParticleSystem targetParticle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var emission = targetParticle.emission;
        emission.rateOverTime = maxRate * intensity;

    }
}
