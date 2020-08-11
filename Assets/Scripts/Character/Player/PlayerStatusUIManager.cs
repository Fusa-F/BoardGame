using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerStatusUIManager : MonoBehaviour
{
    RectTransform rect;
    [Header("移動位置")][SerializeField] public float yPos = 200f;
    //子要素オブジェクト群
    public List<GameObject> elements = new List<GameObject>();

    void Awake()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
    } 
    void Start()
    {
        // rect = this.gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        
    }

    ///<summary>
    ///UIオブジェクトの取得・値の受け渡し
    ///</summary>
    public IEnumerator SetElements(CharaStatus status)
    {
        elements[0].GetComponent<StatusBarManager>().SetValue(status.hp, status.maxHp);
        elements[1].GetComponent<StatusBarManager>().SetValue(status.exp, status.maxExp);
        elements[2].GetComponent<StatusTextManager>().SetText(status.name.ToString());
        elements[3].GetComponent<StatusTextManager>().SetLevel(status.level.ToString());
        elements[4].GetComponent<StatusTextManager>().SetPower(status.power.ToString());
        elements[5].GetComponent<StatusTextManager>().SetMoney(status.money.ToString());
        
        //UI表示位置へ移動
        rect.DOLocalMoveY(yPos * (-1), 1f).SetRelative();
        yield return null;
    }
    
    public IEnumerator RemoveUI()
    {
        //UI非表示位置へ移動
        rect.DOLocalMoveY(yPos, 1f).SetRelative();
        yield return null;
    }
}
