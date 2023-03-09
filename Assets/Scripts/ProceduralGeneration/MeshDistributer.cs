using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDistributer : MonoBehaviour
{
    public virtual void AcceptMesh(Mesh mesh)
    {
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
