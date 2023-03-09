using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndExitButtonManager : MonoBehaviour, IState
{
    public GameObject saveandexitButton;

    public bool endState()
    {
        saveandexitButton.SetActive(false);
        return true;
    }

    public bool startState()
    {
        saveandexitButton.SetActive(true);
        return true;
    }

    public bool updateState()
    {
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PlayerStateManager.Get().getCurrentState() != null)
            {
                PlayerStateManager.Get().clearState();
            }
            else
            {
                PlayerStateManager.Get().setCurrentState(this);
            }
                 
        }

    }
}
