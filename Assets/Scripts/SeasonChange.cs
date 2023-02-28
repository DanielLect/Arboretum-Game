using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonChange : MonoBehaviour
{
    
    public GameObject[] seasonalObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int lastSeason = -1;
    // Update is called once per frame
    void Update()
    {
        int currSeason = (int)TimeManager.Get().currentSeason;

        if (currSeason != lastSeason)
        {
            lastSeason = currSeason;
            clearCurrentObjects();
            seasonalObjects[currSeason].SetActive(true);
        }
    }

    void clearCurrentObjects()
    {
        foreach (GameObject go in seasonalObjects)
        {
            go.SetActive(false);
        }
    }
}
