using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMap : Map
{
    public override float calculate(float x, float z, float seed)
    {
        float distance = Vector2.Distance(new Vector2(x, z), center);

        float temp = ((distance - minDistance) / (maxDistance - minDistance));
        temp = Mathf.Clamp(temp, 0, 1);
        return 1 - temp;
    }
    public Vector2 center;
    public float minDistance;
    public float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
