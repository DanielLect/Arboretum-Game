using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    Mesh mesh;



    public float tileSize = 1;
    public int gridSize = 50;

    public float seed = 0;

    public float perlinSize = 0.5f;
    public float elevationIntensity = 1;

    public MeshDistributer lower;
    public MeshDistributer upper;

    public float heightSeparation;

    public Map[] maps;



    // Start is called before the first frame update
    void Start()
    {
    }

    Vector3[] makeVertices(int xSize, int zSize)
    {
        Vector3[] result = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int z = 0; z < (zSize + 1); z++)
        {
            for (int x = 0; x < (xSize + 1); x++)
            {
                result[x + z * (xSize + 1)] = new Vector3(tileSize*x, getElevation(x, z), tileSize*z);
            }
        }

        return result;

    }

    Vector2[] makeUVs(Vector3[] vertices)
    {
        Vector2[] result = new Vector2[vertices.Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        return result;
    }


    public float getElevation(int x, int z)
    {
        float elevation = 1;

        if (maps != null)
        {
            foreach (Map map in maps)
            {
                elevation *= map.calculate(x, z, seed);
            }
        }
        return elevation * elevationIntensity;

        //return elevationIntensity ;
    }

    Triangle[] makeTriangles(int xSize, int zSize)
    {
        Triangle[] result = new Triangle[xSize * zSize * 2];

        for (int i = 0; i < result.Length / 2; i++)
        {
            int firstIndex = i+i/xSize;

            Triangle[] quad = Triangle.Quad(firstIndex, xSize);
            result[i*2] = quad[0];
            result[i*2+1] = quad[1];

        }

        return result;
    }

    Triangle[][] splitByHeight(Triangle[] allTriangles, Vector3[] vertices, float height)
    {

        List<Triangle> aboveList = new List<Triangle>();
        List<Triangle> belowList = new List<Triangle>();


        for (int i = 0; i < allTriangles.Length; i++)
        {
            if (allTriangles[i].getAverageElevation(vertices) >= height)
            {
                aboveList.Add(allTriangles[i]);
            } else
            {
                belowList.Add(allTriangles[i]);
            }
        }

        Triangle[][] result = new Triangle[2][];
        result[0] = aboveList.ToArray();
        result[1] = belowList.ToArray();

        return result;

    }


    public void createTerrain(float seed)
    {
        this.seed = seed;

        Mesh upperMesh = new Mesh();
        Mesh lowerMesh = new Mesh();

        Vector3[] vertices = makeVertices(gridSize, gridSize);
        Vector2[] uv = makeUVs(vertices);
        Triangle[] trianglesRaw = makeTriangles(gridSize, gridSize);

        Triangle[][] triangles = splitByHeight(trianglesRaw, vertices, heightSeparation);

        upperMesh.Clear();
        upperMesh.vertices = vertices;
        upperMesh.uv = uv;
        upperMesh.triangles = Triangle.TrianglesToInt(triangles[0]);
        upperMesh.RecalculateNormals();

        lowerMesh.Clear();
        lowerMesh.vertices = vertices;
        lowerMesh.uv = uv;
        lowerMesh.triangles = Triangle.TrianglesToInt(triangles[1]);
        lowerMesh.RecalculateNormals();


        //GetComponent<MeshCollider>().sharedMesh = upperMesh;

        upper.AcceptMesh(upperMesh);
        lower.AcceptMesh(lowerMesh);
        //altMesh.mesh = lowerMesh;
    }

    // Update is called once per frame
    void Update()
    {

    }


    bool needsGizmoRedraw = false;

    private void OnValidate()
    {
        needsGizmoRedraw = true;
    }

    [SerializeField]
    private bool gizmosDrawHeight = false;
    Vector3[] verticeGizmo;
    int[] trianglesGizmo;

    private void OnDrawGizmos()
    {
        if (needsGizmoRedraw)
        {

            verticeGizmo = makeVertices(gridSize, gridSize);
            trianglesGizmo = Triangle.TrianglesToInt(makeTriangles(gridSize, gridSize));
        }

        foreach (Vector3 vec3 in verticeGizmo)
        {
            Gizmos.DrawWireSphere(transform.position + vec3, 0.02f);
        }

        for (int i = 0; i < trianglesGizmo.Length; i += 3)
        {
            Vector3 v1 = transform.position + verticeGizmo[trianglesGizmo[i]];
            Vector3 v2 = transform.position + verticeGizmo[trianglesGizmo[i + 1]];
            Vector3 v3 = transform.position + verticeGizmo[trianglesGizmo[i + 2]];

            Gizmos.DrawLine(v1, v2);
            Gizmos.DrawLine(v1, v3);
            Gizmos.DrawLine(v2, v3);
        }

        Vector3 max = new Vector3((gridSize + 1) * tileSize, 0, (gridSize + 1) * tileSize);
        if (gizmosDrawHeight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position + max / 2 + new Vector3(0, heightSeparation, 0), max + new Vector3(0, 0.1f, 0));
        }


    }
}
