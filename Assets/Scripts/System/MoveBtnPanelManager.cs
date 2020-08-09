using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveBtnPanelManager : MonoBehaviour
{
    RectTransform rect;
    //表示・非表示時の移動距離
    [SerializeField]public float distance = 300f;

    //子要素ボタン
    public List<GameObject> btns = new List<GameObject>();

    //Searchingオブジェクト
    public GameObject searching;
    public List<GameObject> searchList = new List<GameObject>();

    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
        
        foreach (Transform child in transform)
        {
            btns.Add(child.gameObject);
        }
    }

    ///<summary>
    ///player移動ボタン表示・非表示
    //PlayerMoveCounterから呼び出し
    ///</summary>
    public IEnumerator EnableMoveBtn(GameObject player)
    {
        //壁判定リスト・ボタンイベントリセット
        searchList.Clear();
        RemoveBtnEvent();

        //表示
        rect.DOLocalMove(new Vector2(0, distance), 1f).SetRelative();  
        SetSearchingArea(player);    
        SetBtnEvent(player);

        while(PlayerMoveCounter.pmCounter.num <= 0)
        {
            yield return null;
        }
        while(PlayerMoveCounter.pmCounter.num > 0)
        {
            for(int i = 0; i < btns.Count; i++)
            {
                bool judge = searchList[i].GetComponent<PlayerSearchAreaManager>().GetIsWall();
                btns[i].GetComponent<MoveBtnManager>().SetInteractable(judge);
            }
            yield return null;
        }

        //非表示
        rect.DOLocalMove(new Vector2(0, distance * -1f), 1f).SetRelative();    
        searchList.Clear();  
    }

    //壁探知エリア取得
    public void SetSearchingArea(GameObject player)
    {
        searching = player.transform.Find("SearchAreaManager").gameObject;  
        foreach (Transform child in searching.transform)
        {
            searchList.Add(child.gameObject);
        }
    }

    //ボタンイベント
    private void SetBtnEvent(GameObject player)
    {
        CharaController cont = player.GetComponent<CharaController>();
        btns[0].GetComponent<Button>().onClick.AddListener(cont.MoveUp);
        btns[1].GetComponent<Button>().onClick.AddListener(cont.MoveRight);
        btns[2].GetComponent<Button>().onClick.AddListener(cont.MoveDown);
        btns[3].GetComponent<Button>().onClick.AddListener(cont.MoveLeft);
    }
    //ボタンイベント削除
    private void RemoveBtnEvent()
    {
        foreach(GameObject btn in btns)
        {
            btn.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
}
