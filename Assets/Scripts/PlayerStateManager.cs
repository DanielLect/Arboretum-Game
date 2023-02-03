using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    static PlayerStateManager manager;

    IState currentState;

    static readonly string input_escape = "escape_button";

    // Start is called before the first frame update
    void Start()
    {
        manager = this;
    }

    public static PlayerStateManager Get()
    {
        return manager;
    }

    public bool setCurrentState(IState state)
    {
        if (currentState == null)
        {
            currentState = state;
            return true;
        }
        //if state end was sucessful
        if (currentState.endState())
        {
            currentState = state;
            return true;
        }
        return false;
    }
    public IState getCurrentState()
    {
        return currentState;
    }

    public bool clearState()
    {
        if (currentState == null)
        {
            return false;
        }
        if (currentState.endState())
        {
            currentState = null;
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("escape_button") == 1)
        {
            clearState();
        }
    }
}