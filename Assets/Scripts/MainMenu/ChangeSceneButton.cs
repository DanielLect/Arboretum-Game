using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ChangeSceneButton : MonoBehaviour
{
    public string targetScene;
    void Start()
    {

        string path = Application.persistentDataPath + "/" + "save" + ".bin";
        if (!File.Exists(path))
        {
            gameObject.SetActive(false);
        }

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadScene);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }


}
