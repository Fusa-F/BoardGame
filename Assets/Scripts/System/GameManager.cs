using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summery>
///列挙型でゲーム内状態を定義
///</summery>
public enum GameState
{
    Select,
    Field,
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

        SetGameState(GameState.Select);        
    }

    ///<summery>
    ///ゲーム内状態の設定
    ///</summery>
    public void SetGameState(GameState state)
    {
        currentState = state;
    }
}
