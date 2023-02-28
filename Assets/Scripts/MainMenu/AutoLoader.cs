using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveLoadManager.loadScene("save");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
