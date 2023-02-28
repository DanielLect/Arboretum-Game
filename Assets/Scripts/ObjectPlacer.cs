using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectPlacer : MonoBehaviour,IPointerDownHandler, IState
{
    bool active = false;
    public GameObject placed_prefab;
    public GameObject preview_prefab;

    public Color activeColor;
    public Color idleColor;

    public GameObject preview_placed_instance;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!active)
        {
            PlayerStateManager.Get().setCurrentState(this);
        } else
        {
            PlayerStateManager.Get().clearState();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    preview_placed_instance.transform.position = hit.point;
                    preview_placed_instance.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                    preview_placed_instance.transform.Rotate(new Vector3(90, 0, 0), Space.Self);

                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject.Destroy(preview_placed_instance);
                        preview_placed_instance = GameObject.Instantiate(placed_prefab);
                        preview_placed_instance.transform.position = hit.point;
                        preview_placed_instance.transform.Rotate(hit.normal, Random.value * 360f, Space.World);

                        Growth deleteLater = preview_placed_instance.GetComponent<Growth>();

                        if (deleteLater != null)
                        {
                            deleteLater.testmethoddelete();
                        }

                        preview_placed_instance = GameObject.Instantiate(preview_prefab);
                    }
                }
            }

        }
        
    }

    public bool endState()
    {
        active = false;
        GetComponent<Image>().color = idleColor;
        if (preview_placed_instance != null)
        {
            GameObject.Destroy(preview_placed_instance);
            preview_placed_instance = null;
        }

        return true;
    }

    public bool startState()
    {
        active = true;
        preview_placed_instance = GameObject.Instantiate(preview_prefab);
        //spawn the placed_instance far away so it doesnt get in the way
        preview_placed_instance.transform.position = Vector3.one * -100;
        GetComponent<Image>().color = activeColor;
        return true;
    }
}
