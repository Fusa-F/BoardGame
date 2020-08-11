using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharaController : MonoBehaviour
{
    //移動距離
    [SerializeField] private float step = 1f;
    //移動速度
    [SerializeField] private float speed = .5f;
    //インターバル
    private float interval = .8f;
    //移動フラグ
    [SerializeField] private bool isMoved = true;

    //現在地
    public Vector2 pos;
    public Vector2 prevPos;
    Sequence moveSeq;

    //攻撃探知エリア
    public GameObject skillArea;
    PlayerSkillInstantiater skillInst;

    void Start()
    {
        pos = this.transform.position;  
        prevPos = pos;
        skillInst = skillArea.GetComponent<PlayerSkillInstantiater>();   
    }

    ///<summary>
    ///入力・移動　移動回数を返す
    ///</summary>
    public void MInput()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else
        {
        }
    }

    //PlayerMoveCounterで呼び出し
    public IEnumerator MoveInput()
    {
        isMoved = true;
        while(PlayerMoveCounter.pmCounter.num > 0)
        {
            MInput();
            if(pos != prevPos)
            {
                prevPos = pos;
                PlayerMoveCounter.pmCounter.num--;
                yield return new WaitForSeconds(interval);
            }
            yield return null;
        }
        yield return null;
    }

    ///<summary>
    ///上下左右移動メソッド
    ///</summary>
    public void MoveUp()
    {
        if(isMoved)
        {
            isMoved = false;
            pos.y += step;
            moveSeq = MoveSequence();
            moveSeq.Play();
        }
    }
    public void MoveDown()
    {
        if(isMoved)
        {
            isMoved = false;
            pos.y -= step;
            moveSeq = MoveSequence();
            moveSeq.Play();  
        }
        
    }
    public void MoveRight()
    {
        if(isMoved)
        {
            isMoved = false;
            pos.x += step;
            moveSeq = MoveSequence();
            moveSeq.Play();            
        }
    }
    public void MoveLeft()
    {
        if(isMoved)
        {
            isMoved = false;
            pos.x -= step;
            moveSeq = MoveSequence();
            moveSeq.Play();            
        }
    }
    public Sequence MoveSequence()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(pos, speed))
                .Join(transform.DOScale(new Vector2(.5f, .5f), .1f))
                .Append(transform.DOScale(new Vector2(1f, 1f), .1f))
                .AppendCallback(() => {
                    pos = this.transform.position;
                    isMoved = true;
                    StartCoroutine(skillInst.InstantiateSkill(this.transform.position));
                });

        return sequence;
    }
}
