using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateParticleSimulationSpeed : MonoBehaviour
{
    private ParticleSystem targetParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = targetParticle.main;
        main.simulationSpeed = TimeManager.Get().timeScale;
    }
}
