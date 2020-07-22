using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerStatusUIManager : MonoBehaviour
{
    RectTransform rect;
//    void Awake()
//    {
//         rect = this.gameObject.GetComponent<RectTransform>();
//         rect.DOLocalMoveY(400f, 0f).SetRelative();
//    } 
    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
        rect.DOLocalMoveY(-300f, 1f).SetRelative();
    }

    void Update()
    {
        
    }
}
