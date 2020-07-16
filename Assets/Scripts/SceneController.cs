using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //static変数(SceneController.sceneで呼び出し可)
    public static SceneController scene;
    public string[] scenes = {
        "TitleScene",
        "SampleScene",
        "SelectScene",
        "MainScene"
    };

    void Awake()
    {
        if(scene == null)
        {
            scene = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TitleToSample()
    {
        SceneManager.LoadScene(scenes[1]);
    }
    public void SelectToMain()
    {
        SceneManager.LoadScene(scenes[3]);
    }

}
