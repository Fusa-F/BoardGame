using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RndNumPanelManager : MonoBehaviour
{
    RectTransform rect;

    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();

        rect.DOLocalMove(new Vector2(-200f, 0), 1f).SetRelative();
    }

    void Update()
    {
        
    }
}
