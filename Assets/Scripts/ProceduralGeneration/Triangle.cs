using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A triangle for procedural mesh generation
public class Triangle
{
    public Triangle(int v1, int v2, int v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }
    int v1, v2, v3;

    public float getAverageElevation(Vector3[] vertices)
    {
        return (vertices[v1].y+vertices[v2].y+vertices[v3].y)/3.0f;
    }

    //create two triangles from Quad
    public static Triangle[] Quad(int bottomLeft, int size)
    {
        Triangle[] result = new Triangle[2];
        /* PICTURE VISUALIZATION
        * b = bottomLeft
        * b+1 = bottomLeft + 1
        * b+s+1 = bottomLeft + size + 1
        * b+s+2 = bottomLeft + size + 2
        *
        *
        * (b+s+1)  (b+s+2)
        *    0------0
        *    |\     |
        *    | \    |
        *    |  \   |
        *    |   \  |
        *    |    \ |
        *    |     \|
        *    0------0
        *  (b)     (b+1)
        *  
        *  First Triangle = b+s+1 -> b+1 -> b (Left Triangle)
        *  Second Triangle = b+s+2 -> b+1 -> b+s+1 (Right Triangle)
        */

        result[0] = new Triangle(bottomLeft + size + 1, bottomLeft + 1, bottomLeft);
        result[1] = new Triangle(bottomLeft + size + 2, bottomLeft + 1, bottomLeft + size + 1);

        return result;
    }

    public static int[] TrianglesToInt(Triangle[] triangles)
    {
        int[] result = new int[triangles.Length * 3];

        for (int i = 0; i < triangles.Length; i++)
        {
            result[i * 3] = triangles[i].v1;
            result[i * 3 + 1] = triangles[i].v2;
            result[i * 3 + 2] = triangles[i].v3;
        }
        return result;
    }
}
