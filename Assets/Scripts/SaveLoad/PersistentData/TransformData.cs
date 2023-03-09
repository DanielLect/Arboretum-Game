using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformData : PersistentData
{
    float[] position;
    float[] rotation;
    float[] scale;
    protected override GameObject load(GameObject gameObject)
    {
        gameObject.transform.position = new Vector3(position[0],position[1],position[2]);
        gameObject.transform.rotation = new Quaternion(rotation[0],rotation[1],rotation[2],rotation[3]);
        gameObject.transform.localScale = new Vector3(scale[0],scale[1],scale[2]);

        return gameObject;
    }

    protected override GameObject save(GameObject gameObject)
    {
        position = new float[3];
        rotation = new float[4];
        scale = new float[3];

        position[0] = gameObject.transform.position.x;
        position[1] = gameObject.transform.position.y;
        position[2] = gameObject.transform.position.z;

        rotation[0] = gameObject.transform.rotation.x;
        rotation[1] = gameObject.transform.rotation.y;
        rotation[2] = gameObject.transform.rotation.z;
        rotation[3] = gameObject.transform.rotation.w;

        scale[0] = gameObject.transform.localScale.x;
        scale[1] = gameObject.transform.localScale.y;
        scale[2] = gameObject.transform.localScale.z;

        return gameObject;
    }

}
