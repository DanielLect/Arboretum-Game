using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabUI : MonoBehaviour, IPointerDownHandler
{
    public Vector3 outPosition;
    public Vector3 inPosition;

    public bool setCurrent;

    private void OnValidate()
    {
        if (setCurrent)
        {
            outPosition = GetComponent<RectTransform>().anchoredPosition;
            inPosition = outPosition;
            setCurrent = false;
        }
    }

    bool isActive = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isActive = !isActive;
        if (isActive)
        {

            transform.GetComponent<RectTransform>().anchoredPosition = outPosition;
        } else
        {

            transform.GetComponent<RectTransform>().anchoredPosition = inPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<RectTransform>().anchoredPosition = inPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
