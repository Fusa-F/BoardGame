using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController sceneController;
    public string[] scenes = {
        "TitleScene",
        "SampleScene"
    };

    void Awake()
    {
        if(sceneController == null)
        {
            sceneController = this;
            DontDestroyOnLoad(gameObject);
        }else
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

}
