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
        growing_object.transform.localScale = start_size;//GetStartingSize();

        buildGrowthResources();
        

    }

    private GrowthResource[] growthResources;

    [SerializeField]
    private GrowthStage[] growthStages;

    [SerializeField]
    private string tree_name;

    [SerializeField]
    private bool isDecidous;
    [SerializeField]
    private Season winterSeason;

    public string getName()
    {
        return tree_name;
    }
    void buildGrowthResources()
    {
        growthResources = new GrowthResource[2];

        GrowthResource[] componentResources = GetComponents<GrowthResource>();
        foreach (GrowthResource componentResource in componentResources)
        {
            growthResources[(int) componentResource.resourceType] = componentResource;
        }
    }

    public GrowthResource getResource(ResourceType type)
    {
        return growthResources[(int)type];
    }

    public GrowthStage getCurrentStage()
    {
        if (currentStage >= growthStages.Length)
        {
            return growthStages[growthStages.Length - 1];
        }
        return growthStages[currentStage];
    }

    public float getPercentage()
    {
        float sum = 0;
        for (int i = 0; i < growthStages.Length; i++)
        {
            sum += growthStages[i].getPercentage();
        }
        return Mathf.Clamp(sum / growthStages.Length,0,1);
    }

    public void setPercentage(float input)
    {
        float percentage = input*growthStages.Length;
        currentStage = 0;
        while (true)
        {
            if (percentage > 1)
            {
                getCurrentStage().setPercentage(1);
                percentage += -1;
                currentStage++;
            } else
            {
                getCurrentStage().setPercentage(percentage);
                percentage += -percentage;
                break;
            }
        }
    }

    void growCurrent()
    {
        if (currentStage < growthStages.Length)
        {
            GrowthStage current = growthStages[currentStage];

            current.Grow(this);
            if (current.Advance())
            {
                currentStage++;
            }
        }
    }

    public Vector3 start_size;
    public Vector3 end_size;

    //public GameObject foiliage;
    public GameObject growing_object;
    //public float growthRate;
    //public float age;
    //public float deltaGrowth;
    //public Vector3 starting_size = new Vector3(0f, 0f, 0f); 
    //public int treeStage;

    //public float[] starting_age;
    //public float[] ending_size;

    int currentStage;
    //public float[] required_sunlight;
    //public float[] required_water;
    

    // Update is called once per frame
    void Update()
    {
        //treeStage = TreeStage();
        //age += GetTimeScale();
        //growthRate = UpdateGrowthRate(TreeStage());
        //if (!NutrientsMet())
        //{
        //growthRate = 0f;
        //}
        //deltaGrowth += GetTimeScale() * growthRate;
        //growing_object.transform.localScale = new Vector3(deltaGrowth, deltaGrowth, deltaGrowth);

        
        if (!isDecidous || SeasonManager.Get().getCurrentSeason() != winterSeason)
        {
            growCurrent();
        }

        growing_object.transform.localScale = start_size+getPercentage()*(end_size - start_size);



    }
    //returns 0-3 depending on what stage the tree is in (0 being seedling, 3 being mature)
    /*int TreeStage() 
    {
        int temp = 0;
        for(int i = 0; i < starting_age.Length; i++)
        {
            if (age > starting_age[i])
            {
                temp = i;
            }
        }
        return temp;*?
    }*/
    /*float UpdateGrowthRate(int tree_int)
    {
        if (tree_int == starting_age.Length - 1)
        {
            //stops the tree from growing if it reaches the last entry in the ending size array
            if (growing_object.transform.localScale.x >= ending_size[tree_int]) 
            {
                return 0f;
            }
            return ending_size[tree_int] * (1 / starting_age[tree_int]);
        }
        return ending_size[tree_int] * (1 / starting_age[tree_int + 1]);


    }*/
    /*
    float GetSunlight()
    { 
        return SunManager.Get().dayValue*sunlight; 
    }*/
    float GetTimeScale()
    {
        return Time.deltaTime * TimeManager.Get().timeScale;
    }
    /*Vector3 GetStartingSize()
    {
        return starting_size;
    }
    bool NutrientsMet()
    {
        int temp = TreeStage();
        bool sunlightMet = getResource(ResourceType.Sunlight).has(growthStages[temp].required_sunlight);
        return (sunlightMet);
    }*/
}
