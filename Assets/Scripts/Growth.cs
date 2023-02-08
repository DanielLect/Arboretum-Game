using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class Growth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        growing_object.transform.localScale = GetStartingSize();

    }

    //public GameObject foiliage;
    public GameObject growing_object;
    public float growthRate;
    public float timeScale;
    public float age;
    public float deltaGrowth;
    public float sunlight;
    public float water;
    public Vector3 starting_size = new Vector3(0f, 0f, 0f);

    public float[] starting_age;
    public float[] ending_size;
    public float[] required_sunlight;
    public float[] required_water;
    

    // Update is called once per frame
    void Update()
    { 
        age += GetTimeScale();
        growthRate = UpdateGrowthRate(TreeStage());
        if (!NutrientsMet())
        {
            growthRate = 0f;
        }
        deltaGrowth = Time.deltaTime * GetTimeScale() * growthRate;
        growing_object.transform.localScale += new Vector3(deltaGrowth, deltaGrowth, deltaGrowth);



    }
    //returns 0-3 depending on what stage the tree is in (0 being seedling, 3 being mature)
    int TreeStage() 
    {
        int temp = 0;
        for(int i = 0; i < starting_age.Length - 1; i++)
        {
            if (age > starting_age[i])
            {
                temp = i;
            }
        }
        return temp;
    }
    float UpdateGrowthRate(int tree_int)
    {
        if (tree_int == starting_age.Length - 1)
        {
            return ending_size[starting_age.Length - 1] * (1 / starting_age[starting_age.Length - 1]);
        }
        return ending_size[tree_int] * (1 / starting_age[tree_int + 1]);


    }
    float GetSunlight()
    { 
        return sunlight; 
    }
    float GetWater()
    {
        return water;
    }
    float GetTimeScale()
    {
        return Time.deltaTime * timeScale;
    }
    Vector3 GetStartingSize()
    {
        return starting_size;
    }
    bool NutrientsMet()
    {
        int temp = TreeStage();
        return (required_sunlight[temp] <= GetSunlight() && required_water[temp] <= GetWater());
    }
}
