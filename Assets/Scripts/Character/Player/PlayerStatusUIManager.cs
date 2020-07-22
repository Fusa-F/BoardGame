using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerStatusUIManager : MonoBehaviour
{
    RectTransform rect;
    public List<GameObject> elements = new List<GameObject>();
   void Awake()
   {
        rect = this.gameObject.GetComponent<RectTransform>();
        //すべての子要素UIの取得
        foreach(Transform child in this.gameObject.transform)
        {
            elements.Add(child.gameObject);
        }
   } 
    void Start()
    {
        // rect = this.gameObject.GetComponent<RectTransform>();
        rect.DOLocalMoveY(-200f, 1f).SetRelative();
    }

    void Update()
    {
        
    }
}
