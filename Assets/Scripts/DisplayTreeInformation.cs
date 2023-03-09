using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTreeInformation : MonoBehaviour, IWorldClickable, IState
{
    Growth growth;
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private GameObject selectedGraphic;

    GameObject instance;
    
    public void onClick()
    {
        if ((object)PlayerStateManager.Get().getCurrentState() == this)
        {
            PlayerStateManager.Get().clearState();
        }
        else
        {
            PlayerStateManager.Get().setCurrentState(this);
        }
    }
    public bool endState()
    {
        GameObject.Destroy(instance);
        instance = null;
        selectedGraphic.SetActive(false);
        return true;
    }


    public bool startState()
    {
        instance = GameObject.Instantiate(prefab);
        selectedGraphic.SetActive(true);
        return true;
    }

    public bool updateState()
    {
        instance.GetComponent<StatDisplay>().updateDisplay(growth);
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        growth = GetComponent<Growth>();
        selectedGraphic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
