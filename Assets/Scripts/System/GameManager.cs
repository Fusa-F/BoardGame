using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summery>
///列挙型でゲーム内状態を定義
///</summery>
public enum GameState
{
    Title,
    Select,
    Main,
    Battle
}
public class GameManager : MonoBehaviour
{
    //static変数(GameManager.Instanceで呼び出し可)
    public static GameManager Instance;
    //現在のstate情報
    public GameState currentState;

    //player人数
    public int playerNumber;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    ///<summery>
    ///ゲーム内状態(state)の設定
    ///</summery>
    public void SetGameState(GameState state)
    {
        currentState = state;
        ChangeScene(state);
    }
    //test
    public void SetBattle()
    {
        if(currentState != GameState.Battle)
        {
            currentState = GameState.Battle;
        }
        else
        {
            currentState = GameState.Main;
        }
        Debug.Log(currentState);
    }

    ///<summery>
    ///ゲーム内状態(state)を参照してシーン遷移メソッド呼び出し
    ///</summery>
    public void ChangeScene(GameState state)
    {
        if(state == GameState.Title)
        {
            SceneController.scene.ToTitle();
        }
        else if(state == GameState.Select)
        {
            SceneController.scene.ToSelect();
        }
        else if(state == GameState.Main)
        {
            SceneController.scene.ToMain();
        }
        else
        {
            Debug.Log("this state has NOT the scene");
        }
    }
}
