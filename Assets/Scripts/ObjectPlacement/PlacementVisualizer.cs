using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementVisualizer : MonoBehaviour
{
    public GameObject validPlacement;
    public GameObject invalidPlacement;

    public void setPlacement(bool b)
    {
        validPlacement.SetActive(b);
        invalidPlacement.SetActive(!b);
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
