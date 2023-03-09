using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{

    [SerializeField]
    private Season[] seasons;

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

    public Season getCurrentSeason()
    {
        return seasons[(int)TimeManager.Get().currentSeason];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
