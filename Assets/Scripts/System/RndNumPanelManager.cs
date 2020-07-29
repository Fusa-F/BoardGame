using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RndNumPanelManager : MonoBehaviour
{
    RectTransform rect;

    //子テキスト
    public GameObject child;
    Text text;

    void Start()
    {
        rect = this.gameObject.GetComponent<RectTransform>();
        rect.DOLocalMove(new Vector2(-200f, 0), 1f).SetRelative();

        text = child.GetComponent<Text>();
        text.text = "あと" + PlayerMoveCounter.pmCounter.num.ToString() + "歩";        
    }

    void FixedUpdate()
    {
        text.text = "あと" + PlayerMoveCounter.pmCounter.num.ToString() + "歩";    
        if(PlayerMoveCounter.pmCounter.num <= 0)
        {
            rect.DOLocalMove(new Vector2(200f, 0), 1f).SetRelative().OnComplete(()=>{
                Destroy(this.gameObject);
            });
        }    
    }
}
