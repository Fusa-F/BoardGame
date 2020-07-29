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
    }

    void Update()
    {
        
    }

    ///<summary>
    ///サイコロオブジェクト呼び出し->出目numの決定
    ///</summary>
    public void InstantiateDice()
    {
        GameObject dice = (GameObject)Instantiate(dicePanel);
        dice.transform.SetParent(canvas.transform, false);
    }

    public void test()
    {
        foreach (GameObject p in GameManager.Instance.playerNumber)
        {
            MoveCount(p);
        }
    }
    ///<summary>
    ///player移動・歩数管理メソッド
    ///引数に移動するplayerを当てて外部から呼び出す
    ///</summary>
    public void MoveCount(GameObject player)
    {
        //コントローラー取得
        CharaController cCon = player.GetComponent<CharaController>();

        StartCoroutine("MoveCountCoroutine", cCon);
    }
    public IEnumerator MoveCountCoroutine(CharaController controller)
    {
        while(num > 0)
        {
            num -= controller.MoveInput();
            yield return null;
        }
        Debug.Log(num + ":fin");
    }
}
