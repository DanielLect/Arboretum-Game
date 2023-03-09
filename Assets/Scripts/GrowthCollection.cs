using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthCollection : MonoBehaviour
{
    [SerializeField]
    private GrowthResource[] growthObjects;

    private bool needsUpdate = true;
    
    
    public GrowthResource[] getAllSceneResources()
    {
        if (needsUpdate)
        {
            needsUpdate = false;
            growthObjects = FindObjectsOfType<GrowthResource>();
        }
        return growthObjects;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        needsUpdate = true;
        
    }
}
