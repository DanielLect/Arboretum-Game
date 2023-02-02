using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectPlacer : MonoBehaviour,IPointerDownHandler, IState
{
    bool active = false;
    public GameObject placed_prefab;

    public Color activeColor;
    public Color idleColor;

    public GameObject placed_instance;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!active)
        {
            if (PlayerStateManager.Get().setCurrentState(this))
            {
                active = true;
                placed_instance = GameObject.Instantiate(placed_prefab);
                //spawn the placed_instance far away so it doesnt get in the way
                placed_instance.transform.position = Vector3.one * -100;
                GetComponent<Image>().color = activeColor;
                return;
            }
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
                    placed_instance.transform.position = hit.point;
                    placed_instance.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                    placed_instance.transform.Rotate(new Vector3(90, 0, 0), Space.Self);

                    if (Input.GetMouseButtonDown(0))
                    {
                        placed_instance.transform.Rotate(hit.normal, Random.value * 360f, Space.World);

                        placed_instance = GameObject.Instantiate(placed_prefab);
                    }
                }
            }

        }
        
    }

    public bool endState()
    {
        active = false;
        GetComponent<Image>().color = idleColor;
        if (placed_instance != null)
        {
            GameObject.Destroy(placed_instance);
            placed_instance = null;
        }

        return true;
    }
}
