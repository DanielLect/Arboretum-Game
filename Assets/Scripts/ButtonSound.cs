using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    private SoundProfile sound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(makeSound);
    }

    void makeSound()
    {
        SoundManager.Get().playSound(sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
