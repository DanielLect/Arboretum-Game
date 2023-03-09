using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    bool endState();
    bool startState();

    //return true if the state should be ended
    bool updateState();
}
