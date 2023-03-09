using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    
    float timePassed;

    public void setTime(float f)
    {
        timePassed = f;
    } 
    public float getTime()
    {
        return timePassed;
    }

    public float timeScale;

    [Tooltip("Length of a day in seconds at 1x speed")]
    public float dayLength;

    [Tooltip("Length of a season in days")]
    public float seasonLength;

    public float currentTime;
    public float currentDay;
    public float currentSeason;


    static TimeManager manager;
    public static TimeManager Get()
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
        timePassed += Time.deltaTime * timeScale;
        currentTime = (timePassed % dayLength)/dayLength;
        currentDay = timePassed / dayLength;
        currentSeason = (currentDay / seasonLength) % 4;
    }
}
