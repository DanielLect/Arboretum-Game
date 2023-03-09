using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveSceneButton : MonoBehaviour
{
    public string targetScene;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadScene);
    }
    void LoadScene()
    {
        SaveLoadManager.saveScene("save");
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }
}
