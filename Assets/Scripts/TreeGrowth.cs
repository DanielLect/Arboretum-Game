using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class TreeGrowth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        trunk_origin.transform.localScale= new Vector3(0f,0f,0f);
        //foiliage.transform.localScale = new Vector3(0f,0f,0f);
    }

    //public GameObject foiliage;
    public GameObject trunk_origin;
    public float growthRate;
    public float timeScale;
    public float age;
    public float deltaGrowth;
    public float sunlight;
    public float water;

    //ages and their growth rates
    //first input is the week the stage starts at
    //second input is how much it will scale in that period (0.25 means the tree will scale up that much by its next cycle
    //third input is the sunlight required
    //fourth input is the water required
    public Vector4 seedlingAge; //seedling age must be 0
    public Vector4 sapplingAge;
    public Vector4 youngAge;
    public Vector4 matureAge;

    // Update is called once per frame
    void Update()
    { 
        age += Time.deltaTime * timeScale;
        growthRate = updateGrowthRate(treeStage());
        if (!nutrientsMet())
        {
            growthRate = 0f;
        }
        deltaGrowth = Time.deltaTime * timeScale * growthRate;
        trunk_origin.transform.localScale += new Vector3(deltaGrowth, deltaGrowth, deltaGrowth);
        //foiliage.transform.localScale += new Vector3(deltaGrowth, deltaGrowth, deltaGrowth);



    }
    //returns 0-3 depending on what stage the tree is in (0 being seedling, 3 being mature)
    int treeStage() 
    {
        int temp = 0;
        if (age > seedlingAge[0])
        {
            temp = 0;
        }
        if (age > sapplingAge[0])
        {
            temp = 1;
        }
        if (age > youngAge[0])
        {
            temp = 2;
        }
        if (age > matureAge[0])
        {
            temp = 3;
        }
        return temp;
    }
    float updateGrowthRate(int treeInt)
    {
        float result = 0;
        if (treeInt == 0)
        {
            result = seedlingAge[1] * (1/sapplingAge[0]);
        }
        if (treeInt == 1)
        {
            result = (sapplingAge[1] - seedlingAge[1]) * (1 / (youngAge[0] - sapplingAge[0]));
        }
        if (treeInt == 2)
        {
            result = (youngAge[1] - sapplingAge[1]) * (1 / (matureAge[0]- youngAge[0]));
        }
        if (treeInt == 3)
        {
            result = matureAge[1] * (1 / matureAge[0]);
        }
        return result;


    }
    bool nutrientsMet()
    {
        int treeInt = treeStage();
        if (treeInt == 0)
        {
            return (seedlingAge[2] <= sunlight && seedlingAge[3] <= water);
        }
        if (treeInt == 1)
        {
            return (sapplingAge[2] <= sunlight && sapplingAge[3] <= water);
        }
        if (treeInt == 2)
        {
            return (youngAge[2] <= sunlight && youngAge[3] <= water);
        }
        if (treeInt == 3)
        {
            return (matureAge[2] <= sunlight && matureAge[3] <= water);
        }
        return true;
    }
}
