using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeasonDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int season = (int) TimeManager.Get().currentSeason;

        text.text = SeasonManager.Get().seasons[season].title;
    }
}
