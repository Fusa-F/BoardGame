using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInstantiater : MonoBehaviour
{
    //Playerオブジェクト
    public GameObject playerObj;
    //PlayerステータスUI
    public GameObject playerStatusPanel;
    //UIをのせるcanvas
    public GameObject canvas;

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    void Start()
    {
        playerObj = (GameObject)Resources.Load("Prefab/PlayerChara");
        playerStatusPanel = (GameObject)Resources.Load("Prefab/PlayerStatusPanel");

        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();

        StartCoroutine("StartInstantiate");
    }

    ///<summery>
    ///開始時呼び出すコルーチン
    ///</summery>
    public IEnumerator StartInstantiate()
    {
        if(GameManager.Instance.playerNumber >= 1)
        {
            //入力したプレイヤー人数分生成
            for(int i = 1; i <= GameManager.Instance.playerNumber; i++)
            {
                InstantiatePlayer();
                yield return new WaitForSeconds(2f);
            }

            GameObject playerStatus = (GameObject)Instantiate(playerStatusPanel);
            playerStatus.transform.SetParent(canvas.transform, false);
        }
    }
    ///<summery>
    ///プレイヤー生成
    ///</summery>
    public void InstantiatePlayer()
    {
        int rndX = Random.Range(1, 11);
        int rndY = Random.Range(1, 11);
        GameObject player = (GameObject)Instantiate(playerObj, new Vector2(rndX, rndY), Quaternion.identity);

        //移動メソッド呼び出し     
        cameraController.SetTarget(player);
    }
}
