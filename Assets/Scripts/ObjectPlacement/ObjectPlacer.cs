using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectPlacer : MonoBehaviour, IPointerDownHandler, IState
{
    public GameObject placed_prefab;
    public GameObject preview_prefab;

    public Color activeColor;
    public Color idleColor;

    public SoundProfile clickSound;
    public SoundProfile placeSound;
    public SoundProfile errorSound;

    public GameObject preview_instance;

    public WorldClickableManager clickableManager;

    public PlacementRestriction placementRestriction;
    public void OnPointerDown(PointerEventData eventData)
    {
        if ((object)PlayerStateManager.Get().getCurrentState() == this)
        {
            PlayerStateManager.Get().clearState();
            SoundManager.Get().playSound(clickSound);
        }
        else
        {
            PlayerStateManager.Get().setCurrentState(this);
            SoundManager.Get().playSound(clickSound);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool endState()
    {
        GetComponent<Image>().color = idleColor;

        GameObject.Destroy(preview_instance);
        preview_instance = null;
        clickableManager.enabled = true;

        return true;
    }

    public bool startState()
    {
        GetComponent<Image>().color = activeColor;


        preview_instance = GameObject.Instantiate(preview_prefab);
        //spawn the placed_instance far away so it doesnt get in the way
        preview_instance.transform.position = Vector3.one * -100;
        preview_instance.GetComponent<PlacementVisualizer>().setPlacement(false);

        clickableManager.enabled = false;

        return true;
    }

    public bool updateState()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            int layerMask = LayerMask.GetMask("World");

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, layerMask))
            {
                preview_instance.transform.position = hit.point;
                preview_instance.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                preview_instance.transform.Rotate(new Vector3(90, 0, 0), Space.Self);

                bool validPlacement = placementRestriction.validPlacement(hit.point);

                preview_instance.GetComponent<PlacementVisualizer>().setPlacement(validPlacement);

                if (Input.GetMouseButtonDown(0))
                {
                    if (validPlacement)
                    {
                        placePrefab(hit);
                        SoundManager.Get().playSound(placeSound);
                    }
                    else
                    {
                        SoundManager.Get().playSound(errorSound);

                    }
                }
            }
        }
        return false;
    }

    void placePrefab(RaycastHit hit)
    {
        GameObject placedClone = GameObject.Instantiate(placed_prefab);
        placedClone.transform.position = hit.point;
        placedClone.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
        placedClone.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
        placedClone.transform.Rotate(new Vector3(0, Random.value * 360f, 0), Space.Self);
        //placedClone.transform.Rotate(hit.normal, Random.value * 360f, Space.Self);

    }
}
