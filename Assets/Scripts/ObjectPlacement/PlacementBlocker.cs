using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBlocker : MonoBehaviour
{
    [SerializeField]
    private float radius = 1;
    [SerializeField]
    private Vector3 relativeCenter;
    public Vector3 getBlockerCenter()
    {
        return gameObject.transform.position + relativeCenter;
    }

    public float getBlockerRadius()
    {
        return radius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        //center of the blocker
        Gizmos.DrawSphere(gameObject.transform.position + relativeCenter,0.1f);

        //radius of the blocker
        Gizmos.DrawWireSphere(gameObject.transform.position + relativeCenter, radius);
    }
}
