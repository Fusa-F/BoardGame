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
    ///</summary>
    public IEnumerator EnableMoveBtn()
    {
        //表示
        rect.DOLocalMove(new Vector2(0, distance), 1f).SetRelative();  
        SetSearchingArea();    

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

    public void SetSearchingArea()
    {
        searching = GameObject.FindWithTag("Searching");  
        foreach (Transform child in searching.transform)
        {
            searchList.Add(child.gameObject);
        }
    }
}
