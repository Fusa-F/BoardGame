using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RandomDiceManager : MonoBehaviour
{
    //さいの出目リスト
    public List<int> num = new List<int>();

    //このスクリプトをアタッチしているオブジェクト
    Text text;
    //parent
    GameObject dicePanel;
    RectTransform rect;
    //canvas
    GameObject canvas;

    //UIアニメーションシーケンス
    Sequence diceSeq;

    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        //parent
        dicePanel = transform.parent.gameObject;
        rect = dicePanel.GetComponent<RectTransform>();
        rect.DOLocalMove(new Vector2(0f, -400f), .5f).SetRelative();
        //canvas
        canvas = GameObject.FindWithTag("Canvas");

        StartCoroutine("SetNumText");
    }

    ///<summery>
    ///出目を一定間隔でテキスト表示するコルーチン
    ///</summery>
    public IEnumerator SetNumText()
    {
        Debug.Log("space -> diceStop");
        int rnd = 0;
        while(!Input.GetKeyDown(KeyCode.Space)) {
            rnd = Random.Range(0, num.Count - 1);
            text.text = num[rnd].ToString();
            yield return null;
        }
        //出目管理クラスに入力
        PlayerMoveCounter.pmCounter.num = num[rnd];

        diceSeq = DiceSequence();
        diceSeq.Play();
    }

    ///<summery>
    ///親パネルのアニメーションシーケンス
    ///</summery>
    private Sequence DiceSequence()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rect.DOScale(new Vector2(1.1f, 1.1f), 1f))
                .Append(rect.DOLocalMove(new Vector2(0f, -50f), .2f).SetRelative())
                .Append(rect.DOLocalMove(new Vector2(0f, 450f), .5f).SetRelative())
                .AppendCallback(()=>{
                    GameObject rndNumPanel = (GameObject)Resources.Load("Prefab/RndNumPanel");
                    GameObject rndNumPanelPre = (GameObject)Instantiate(rndNumPanel);
                    rndNumPanelPre.transform.SetParent(canvas.transform, false);

                    Destroy(dicePanel);
                });

        return sequence;
    }
}
