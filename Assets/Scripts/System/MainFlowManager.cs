using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFlowManager : MonoBehaviour
{
    //mainscene オブジェクト
    public GameObject playerInstantiater;
    PlayerInstantiater pInst;
    public GameObject enemyInstantiater;
    EnemyInstantiater eInst;

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    private void Awake() {
        pInst = playerInstantiater.GetComponent<PlayerInstantiater>();
        eInst = enemyInstantiater.GetComponent<EnemyInstantiater>();
        
        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();
    }
    void Start()
    {
        StartCoroutine("MainFlow");
    }

    ///<summary>
    ///ゲームの流れを管理するコルーチン
    ///</summary>
    public IEnumerator MainFlow()
    {
        //player生成
        yield return StartCoroutine(pInst.StartInstantiateCoroutine());
        
        //mainの流れ
        while(true)
        {
            // foreach(GameObject pl in GameManager.Instance.playerNumber)
            // {
            //     yield return StartCoroutine(TurnCoroutine(pl));
            // }  

            //playerターン
            yield return StartCoroutine(TurnCoroutine(GameManager.Instance.playerNumber[0]));   

            //enemy生成
            yield return StartCoroutine(eInst.SummonEnemyRedTile());   

        }
    }
    public IEnumerator TurnCoroutine(GameObject player)
    {
        //移動メソッド呼び出し     
        cameraController.SetTarget(player);

        //player順にサイコロ・移動メソッド
        PlayerMoveCounter.pmCounter.InstantiateDice();
        yield return StartCoroutine(PlayerMoveCounter.pmCounter.MoveCountCoroutine(player));  
        Debug.Log("ok");  

        //tileごとのイベント
    }
}
