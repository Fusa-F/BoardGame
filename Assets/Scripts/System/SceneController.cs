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

    public void ToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void ToSample()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ToSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void ToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

}
