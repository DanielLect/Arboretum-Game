using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{

    public Season[] seasons;

    static SeasonManager manager;

    public static SeasonManager Get()
    {
        return manager;
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
