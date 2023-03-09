using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachAmbienceController : MonoBehaviour
{
    public Vector3 worldCenterPos;
    public float minDistance;
    public float maxDistance;

    AmbientSoundPlayer ambientSoundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ambientSoundPlayer = GetComponent<AmbientSoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        ambientSoundPlayer.volume = getVolume();
    }

    
    float getVolume()
    {
        
        float distance = Vector2.Distance(transform.position, worldCenterPos);

        float temp = ((distance - minDistance) / (maxDistance - minDistance));
        temp = Mathf.Clamp(temp, 0, 1);
        return temp;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(worldCenterPos, 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(worldCenterPos, minDistance);

        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(worldCenterPos,maxDistance);

    }
}
