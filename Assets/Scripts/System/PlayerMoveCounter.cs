using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMoveCounter : MonoBehaviour
{
    //static変数(PlayerMoveCounter.pmCounterで呼び出し可)
    public static PlayerMoveCounter pmCounter;

    //さいの出目変数(外部からSet)
    public int num { get; set; }

    //dice
    public GameObject canvas;
    public GameObject dicePanel;

    //moveBtn
    public GameObject moveBtnPanel;
    MoveBtnPanelManager mbManager;

    void Awake()
    {
        if(pmCounter == null)
        {
            pmCounter = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        dicePanel = (GameObject)Resources.Load("Prefab/DicePanel");
        mbManager = moveBtnPanel.GetComponent<MoveBtnPanelManager>();
    }

    ///<summary>
    ///サイコロオブジェクト呼び出し->出目numの決定
    ///</summary>
    //MainFlowManagerから
    public void InstantiateDice()
    {
        GameObject dice = (GameObject)Instantiate(dicePanel);
        dice.transform.SetParent(canvas.transform, false);
    }

    ///<summary>
    ///player移動・歩数管理コルーチン
    ///引数に移動するplayerを当てて外部から呼び出す
    ///</summary>
    public void MoveCount(GameObject player)
    {
        StartCoroutine("MoveCountCoroutine", player);
    }
    //MainFlowManagerからコルーチンで呼び出している
    public IEnumerator MoveCountCoroutine(GameObject player)
    {
        //コントローラー取得
        CharaController controller = player.GetComponent<CharaController>();

        Debug.Log("start:"+num);
        while(num <= 0)
        {
            yield return null;
        }

        //移動ボタン表示
        StartCoroutine(mbManager.EnableMoveBtn(player));
        //移動コルーチン
        yield return StartCoroutine(controller.MoveInputBtn(num));

        Debug.Log(num + ":fin");
    }
}
