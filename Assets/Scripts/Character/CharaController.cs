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

    //現在地
    private Vector2 pos;
    Sequence moveSeq;

    void Start()
    {
        pos = this.transform.position;     
    }

    // private void Update()
    // {
    //     MoveInput();
    // }

    ///<summary>
    ///入力・移動
    ///</summary>
    public int MoveInput()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
            return 1;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
            return 1;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
            return 1;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
            return 1;
        }
        else
        {
            return 0;
        }
    }

    ///<summary>
    ///上下左右移動メソッド
    ///</summary>
    public void MoveUp()
    {
        pos.y += step;
        moveSeq = MoveSequence();
        moveSeq.Play();
    }
    public void MoveDown()
    {
        pos.y -= step;
        moveSeq = MoveSequence();
        moveSeq.Play();
    }
    public void MoveRight()
    {
        pos.x += step;
        moveSeq = MoveSequence();
        moveSeq.Play();
    }
    public void MoveLeft()
    {
        pos.x -= step;
        moveSeq = MoveSequence();
        moveSeq.Play();
    }
    public Sequence MoveSequence()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector2(1.2f, 1.2f), .1f))
                .Append(transform.DOLocalMove(pos, speed))
                .Join(transform.DOScale(new Vector2(.5f, .5f), .1f))
                .Append(transform.DOScale(new Vector2(1.2f, 1.2f), .1f))
                .Append(transform.DOScale(new Vector2(1f, 1f), .1f));

        return sequence;
    }
}
