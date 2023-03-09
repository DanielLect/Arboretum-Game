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

    public void testmethoddelete()
    {

    }

    //public GameObject foiliage;
    public GameObject growing_object;
    public float growthRate;
    public float age;
    public float deltaGrowth;
    public float sunlight;
    public float water;
    public Vector3 starting_size = new Vector3(0f, 0f, 0f);
    public int treeStage;

    public float[] starting_age;
    public float ending_age;
    public float[] ending_size;
    public float[] required_sunlight;
    public float[] required_water;
    

    // Update is called once per frame
    void Update()
    {
        treeStage = TreeStage();
        age += GetTimeScale() * NutrientsMetModifier();
        growthRate = UpdateGrowthRate(TreeStage());
        if (!NutrientsMet())
        {
            growthRate = 0f;
        }
        deltaGrowth += GetTimeScale() * growthRate;
        growing_object.transform.localScale = new Vector3(deltaGrowth, deltaGrowth, deltaGrowth);



    }
    //returns 0-3 depending on what stage the tree is in (0 being seedling, 3 being mature)
    int TreeStage() 
    {
        int temp = 0;
        for(int i = 0; i < starting_age.Length; i++)
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
            //stops the tree from growing if it reaches the last entry in the ending size array
            if (growing_object.transform.localScale.x >= ending_size[tree_int]) 
            {
                return 0f;
            }
            return ending_size[tree_int] * (1 / ending_age);
        }
        return ending_size[tree_int] * (1 / starting_age[tree_int + 1]);


    }
    public float GetSunlight()
    { 
        return SunManager.Get().dayValue*sunlight; 
    }
    public float getAge()
    {
        return age;
    }
    public float GetWater()
    {
        return water;
    }
    float GetTimeScale()
    {
        return Time.deltaTime * TimeManager.Get().timeScale;
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

    float NutrientsMetModifier()
    {
        if (NutrientsMet())
        {
            return 1;
        }
        return 0;
    }
}
