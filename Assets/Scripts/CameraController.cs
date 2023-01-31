using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 1;
    public float rotationSpeed = 1;
    public float zoomSpeed = 1;

    public Camera controlledCamera;
    public GameObject innerPivot;
    public GameObject heightController;

    public float minZoom = 0.1f;
    public float maxZoom = 10f;

    public float minCamAngle = 5f;
    public float maxCamAngle = 89.9f;

    //these are axis names from the input manager
    readonly static string input_rotation = "camera_rotation";
    readonly static string input_movement = "camera_movement";
    readonly static string input_zoom     = "camera_zoom";
    readonly static string input_mouse_x  = "mouse_x";
    readonly static string input_mouse_y  = "mouse_y";

    Vector3 startCamDir;
    float curCamDistance;

    // Start is called before the first frame update
    void Start()
    {
        startCamDir = controlledCamera.transform.localPosition.normalized;
        curCamDistance = Vector3.Distance(Vector3.zero, controlledCamera.transform.localPosition);

        rotateCamera();
        zoomCamera();
        adjustHeight();
    }

    // Update is called once per frame
    void Update()
    {
        
        //rotation button pressed
        if (Input.GetAxis(input_rotation) == 1)
        {
            rotateCamera();
        }

        //movement button pressed and rotation isnt
        if (Input.GetAxis(input_movement) == 1 && Input.GetAxis(input_rotation) != 1)
        {
            moveCamera();
            adjustHeight();
        }

        if (Input.GetAxis(input_zoom) != 0)
        {
            zoomCamera();
        }
    }

    void rotateCamera()
    {

        //input from mouse movement
        Vector3 outer_pivot_rotation = new Vector3(0, Input.GetAxis(input_mouse_x));
        Vector3 inner_pivot_rotation = new Vector3(-1 * Input.GetAxis(input_mouse_y), 0);


        //rotate
        transform.Rotate(rotationSpeed * outer_pivot_rotation, Space.Self);
        innerPivot.transform.Rotate(rotationSpeed * inner_pivot_rotation, Space.Self);

        //set the z rotation to 0 as the 0 orientation should always stay the same
        float angle = innerPivot.transform.localRotation.eulerAngles.x;
        angle = Mathf.Max(angle, minCamAngle);
        angle = Mathf.Min(angle, maxCamAngle);
        innerPivot.transform.localRotation = Quaternion.Euler(angle, 0, 0);
    }

    void zoomCamera()
    {
        float zoom_input = Input.GetAxis(input_zoom);

        curCamDistance += -1 * zoom_input * zoomSpeed;

        curCamDistance = Mathf.Max(curCamDistance, minZoom);
        curCamDistance = Mathf.Min(curCamDistance, maxZoom);

        controlledCamera.transform.localPosition = startCamDir * curCamDistance;

    }
    void moveCamera()
    {
        Vector3 mouse_input = new Vector3(Input.GetAxis(input_mouse_x), 0, Input.GetAxis(input_mouse_y));

        //forward_axis = transform.right;
        //Vector3 forward_axis = new Vector3(transform.right.z, 0, transform.right.x);

        Vector3 world_movement = transform.right * Input.GetAxis(input_mouse_x) + transform.forward * Input.GetAxis(input_mouse_y);
        world_movement *= -1;

        transform.position += Time.deltaTime * movementSpeed * world_movement;

    }

    void adjustHeight() {
        float targetY = 0;
        RaycastHit raycastInfo;
        if (Physics.Raycast(heightController.transform.position, heightController.transform.up*-1, out raycastInfo, 100))
        {
            targetY = raycastInfo.point.y;
        }
        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

    }
}
