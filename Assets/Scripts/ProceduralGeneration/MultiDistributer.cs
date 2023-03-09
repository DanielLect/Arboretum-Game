using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDistributer : MeshDistributer
{

    public MeshDistributer[] others;
    public override void AcceptMesh(Mesh mesh)
    {
        foreach (MeshDistributer distributer in others)
        {
            distributer.AcceptMesh(mesh);
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
}
