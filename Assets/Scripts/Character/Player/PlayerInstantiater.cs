using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInstantiater : MonoBehaviour
{
    //Playerオブジェクト
    public GameObject playerObj;

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    [Header("test")][SerializeField]public int plNum = 1;

    void Awake()
    {
        playerObj = (GameObject)Resources.Load("Prefab/PlayerChara");

        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();

        // StartCoroutine("StartInstantiate");

        //test
        if(GameManager.Instance.playerNumber.Length <= 0)
        {
            GameManager.Instance.playerNumber = new GameObject[plNum];
        }
    }

    ///<summery>
    ///開始時呼び出すコルーチン(MainFlowManagerから呼ぶ)
    ///</summery>
    public IEnumerator StartInstantiateCoroutine()
    {
        //入力したプレイヤー人数分生成
        for(int i = 0; i < GameManager.Instance.playerNumber.Length; i++)
        {
            GameManager.Instance.playerNumber[i] = InstantiatePlayer();
            yield return new WaitForSeconds(2f);
        }
    }
    ///<summery>
    ///プレイヤー生成
    ///</summery>
    public GameObject InstantiatePlayer()
    {
        int rndX = Random.Range(1, 11);
        int rndY = Random.Range(1, 11);
        GameObject player = (GameObject)Instantiate(playerObj, new Vector2(rndX, rndY), Quaternion.identity);
        SetPlayerStatus(player);

        //移動メソッド呼び出し     
        cameraController.SetTarget(player);

        return player;
    }

    ///<summery>
    ///プレイヤー情報入力
    ///</summery>
    public void SetPlayerStatus(GameObject p)
    {
        CharaStatus status = new CharaStatus(
            "fusa",
            1,
            1000,
            500,
            50,
            1500
        );
        PlayerStatus playerStatus = p.GetComponent<PlayerStatus>();
        playerStatus.SetStatus(status);
    }
}
