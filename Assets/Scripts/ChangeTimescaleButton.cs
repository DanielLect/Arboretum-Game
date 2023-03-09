using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTimescaleButton : MonoBehaviour
{

    public float timescale;
    public bool startingTimescale = false;

    public Color activeColor;
    public Color inactiveColor;

    public Image image;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        image.color = inactiveColor;

        if (startingTimescale)
        {
            changeTimescale();
        }

        button.onClick.AddListener(changeTimescale);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.Get().timeScale != timescale)
        {
            image.color = inactiveColor;
        }
    }


    public void changeTimescale()
    {
        TimeManager.Get().timeScale = timescale;
        image.color = activeColor;
    }
}
