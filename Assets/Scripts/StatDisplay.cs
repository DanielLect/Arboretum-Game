using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text_water;
    [SerializeField]
    private TextMeshProUGUI text_sunlight;
    [SerializeField]
    private RectTransform tf_progress;
    [SerializeField]
    private TextMeshProUGUI text_tree_name;
    [SerializeField]
    private TextMeshProUGUI text_water_use;
    [SerializeField]
    private TextMeshProUGUI text_sunlight_use;

    [SerializeField]
    private Vector2 progressStartSizeDelta;
    public void updateDisplay(Growth growth)
    {
        text_water.text = growth.getResource(ResourceType.Water).GetDisplayString();
        text_sunlight.text = growth.getResource(ResourceType.Sunlight).GetDisplayString();
        tf_progress.sizeDelta = new Vector2(progressStartSizeDelta.x * growth.getCurrentStage().getPercentage(), progressStartSizeDelta.y);
        text_tree_name.text = growth.getName();

        text_water_use.text = growth.getCurrentStage().getWaterUseString();
        text_sunlight_use.text = growth.getCurrentStage().getSunlightUseString();
    }

    private void OnValidate()
    {
        progressStartSizeDelta = tf_progress.sizeDelta;
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
