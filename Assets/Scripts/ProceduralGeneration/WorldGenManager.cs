using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenManager : MonoBehaviour
{

    public MeshCreator creator;

    public float seed;

    static WorldGenManager instance;

    public static WorldGenManager Get()
    {
        return instance;
    }
    //singleton

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        seed = Random.value * 100000;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
