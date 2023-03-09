using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class StatDisplay : MonoBehaviour, IState
{
    public TextMeshProUGUI text;
    private Growth growth = null;
    public GameObject image;
    bool active = false;
    string textOutPut;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
              if (Input.GetMouseButtonDown(0))
            {
                if (isGrowth())
                {
                    PlayerStateManager.Get().setCurrentState(this);
                }
            }
        }
        else
        {
            //PlayerStateManager.Get().clearState();
        }
        if (active)
        {
            float maxsize = growth.ending_age;
            float percent;
            if (growth.getAge() < maxsize)
            {
                percent = growth.getAge() / maxsize;
            }
            else
            {
                percent = 1;
            }
            image.GetComponent<RectTransform>().sizeDelta = new Vector2 (percent * 200f, image.GetComponent<RectTransform>().sizeDelta.y);
            textOutPut = "Stats!!!\nSunlight: " + Mathf.Round(growth.GetSunlight()) + "\nWater: " + Mathf.Round(growth.GetWater()) + "\n" + Mathf.Round(percent * 100) + "%";
            text.text = textOutPut;
        }
    }

    private bool isGrowth()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) 
        { 
            if(hit.collider != null)
            {
                if (hit.collider.GetComponentInParent<Growth>() != null) 
                {
                    growth = hit.collider.GetComponentInParent<Growth>();
                    return true;
                }
            }
        }
        return false;
    }

    public bool endState()
    {
        text.text = "";
        active = false;
        return true;
    }

    public bool startState()
    {
        active = true;
        return true;
    }
}
