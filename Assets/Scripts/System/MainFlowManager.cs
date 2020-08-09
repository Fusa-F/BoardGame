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
    //UI
    public GameObject playerStatusUI;
    PlayerStatusUIManager pUIMana;

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    [Header("ターン管理変数")]
    [SerializeField]
    public float turnInterval = 1f;

    private void Awake() {
        pInst = playerInstantiater.GetComponent<PlayerInstantiater>();
        eInst = enemyInstantiater.GetComponent<EnemyInstantiater>();
        pUIMana = playerStatusUI.GetComponent<PlayerStatusUIManager>();
        
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
            //playerターン
            for(int i = 0; i < GameManager.Instance.playerNumber.Length; i++)
            {
                yield return StartCoroutine(PlayerTurnCoroutine(GameManager.Instance.playerNumber[i]));                   
            }

            //enemy生成
            yield return StartCoroutine(eInst.SummonEnemyRedTile());  

            //enemyターン
            for(int i = 0; i < eInst.enemyObjList.Count; i++)
            {
                yield return StartCoroutine(EnemyTurnCoroutine(eInst.enemyObjList[i]));                   
            }

        }
    }

    ///<summary>
    ///プレイヤーターン
    ///</summary>
    public IEnumerator PlayerTurnCoroutine(GameObject player)
    {
        //移動メソッド呼び出し     
        cameraController.SetTarget(player);
        cameraController.ZoomInCamera();

        CharaStatus status = player.GetComponent<PlayerStatus>().GetStatus();
        //名前出力
        StartCoroutine(TextManager.textManager.TextCoroutine(status.name + "のターン"));
        //statusUI出力
        yield return StartCoroutine(pUIMana.SetElements(status));

        //player順にサイコロ・移動メソッド
        PlayerMoveCounter.pmCounter.InstantiateDice();
        yield return StartCoroutine(PlayerMoveCounter.pmCounter.MoveCountCoroutine(player));  

        //tileごとのイベント

        cameraController.ZoomOutCamera();
        yield return StartCoroutine(pUIMana.RemoveUI());
        yield return new WaitForSeconds(turnInterval);
    }

    ///<summary>
    ///エネミーターン
    ///</summary>
    public IEnumerator EnemyTurnCoroutine(GameObject enemy)
    {
        //移動メソッド呼び出し     
        cameraController.SetTarget(enemy);
        cameraController.ZoomInCamera();

        CharaStatus status = enemy.GetComponent<EnemyStatus>().GetStatus();
        //名前出力
        StartCoroutine(TextManager.textManager.TextCoroutine(status.name + "のターン"));

        // //player順にサイコロ・移動メソッド
        // PlayerMoveCounter.pmCounter.InstantiateDice();
        // yield return StartCoroutine(PlayerMoveCounter.pmCounter.MoveCountCoroutine(player));  
        // Debug.Log("ok");  

        cameraController.ZoomOutCamera();
        yield return new WaitForSeconds(turnInterval);
    }
}
