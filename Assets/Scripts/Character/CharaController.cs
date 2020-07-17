using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharaController : MonoBehaviour
{
    //移動距離
    [SerializeField] private float step = 1f;
    //移動速度
    [SerializeField] private float speed = 1f;

    //現在地
    private Vector2 pos;
    Sequence moveSeq;

    void Start()
    {
        pos = this.transform.position;        
    }

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
        sequence.Append(transform.DOScale(new Vector2(1.2f, 1.2f), .2f))
                .Append(transform.DOLocalMove(pos, speed))
                .Join(transform.DOScale(new Vector2(.5f, .5f), .2f))
                .Append(transform.DOScale(new Vector2(1.2f, 1.2f), .2f))
                .Append(transform.DOScale(new Vector2(1f, 1f), .2f));

        return sequence;
    }
}
