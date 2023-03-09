using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMap : Map
{
    public float size;
    public override float calculate(float x, float z, float seed)
    {
        return Mathf.PerlinNoise(5 * seed + x / size, 10 * seed + z / size);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
