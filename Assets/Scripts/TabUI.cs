using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabUI : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 outPosition;
    public Vector3 inPosition;

    public bool setCurrent;

    public float speed;

    public SoundProfile sound;
    float soundTimePlayed;
    
    [SerializeField]
    private float soundCooldown = 0.2f;


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
        //isActive = !isActive;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<RectTransform>().anchoredPosition = inPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = inPosition;
        if (isActive)
        {
            target = outPosition;
        }

        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, target, speed*Time.deltaTime);

    }
    
    void playSound()
    {
        if (Time.time - soundTimePlayed > soundCooldown)
        {
            soundTimePlayed = Time.time;
            SoundManager.Get().playSound(sound);
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        playSound();
        isActive = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        playSound();
        isActive = false;
    }
}
