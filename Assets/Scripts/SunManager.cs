using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    static SunManager manager;
    public static SunManager Get()
    {
        return manager;
    }

    public float dayPercentage;

    public float dayProgression;
    public float dayValue;
    public float nightProgression;
    public float nightValue;


    public float sunRotationYDelta = 180;
    public float sunRotationXDelta = 85;
    // Start is called before the first frame update
    void Start()
    {
        manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        float time = TimeManager.Get().currentTime;
        if (time >= 0 && time <= dayPercentage)
        {
            dayValue = Mathf.Sin((Mathf.PI * time) / dayPercentage);
            dayProgression = (time / dayPercentage);

            Vector3 newRotation = new Vector3(dayValue * sunRotationXDelta, dayProgression * sunRotationYDelta);

            gameObject.transform.rotation = Quaternion.Euler(newRotation);

            nightValue = 0;
            nightProgression = 0;
        }

        if (time > dayPercentage && time <= 1)
        {

            nightValue = Mathf.Sin((Mathf.PI * (time - dayPercentage)) / (1 - dayPercentage));
            nightProgression = ((time - dayPercentage) / (1 - dayPercentage));

            Vector3 newRotation = new Vector3(nightValue * -sunRotationXDelta, sunRotationYDelta+nightProgression * (360-sunRotationYDelta));

            gameObject.transform.rotation = Quaternion.Euler(newRotation);

            dayValue = 0;
            dayProgression = 0;
        }
    }
}
