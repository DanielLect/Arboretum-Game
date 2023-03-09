using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (currentState != null && !currentState.endState())
        {
            return false;
        }

        currentState = null;

        if (state.startState())
        {
            currentState = state;
        }

        return (currentState != null);
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

        if (currentState != null)
        {
            if (currentState.updateState())
            {
                clearState();
            }
        }
    }
}
