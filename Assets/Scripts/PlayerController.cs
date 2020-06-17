using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float distance = 1f;
    [SerializeField] private float speed = 1f;
    private Vector2 move;
    Sequence moveSeq;

    public GameObject playerManager;
    PlayerManager pManager;
    public GameObject canvas;

    void Start()
    {
        move = this.transform.position;
        pManager = playerManager.GetComponent<PlayerManager>();
    }

    public void MoveUp()
    {
        move.y += distance;
        moveSeq = MoveSequence();
        moveSeq.Play();
    }
    public void MoveDown()
    {
        move.y -= distance;
        moveSeq = MoveSequence();
        moveSeq.Play();
    }
    public void MoveRight()
    {
        move.x += distance;
        moveSeq = MoveSequence();
        moveSeq.Play();
    }
    public void MoveLeft()
    {
        move.x -= distance;
        moveSeq = MoveSequence();
        moveSeq.Play();
    }
    public Sequence MoveSequence()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector2(1.2f, 1.2f), .2f))
                .Append(transform.DOLocalMove(move, speed))
                .Join(transform.DOScale(new Vector2(.5f, .5f), .2f))
                .Append(transform.DOScale(new Vector2(1.2f, 1.2f), .2f))
                .Append(transform.DOScale(new Vector2(1f, 1f), .2f));
        return sequence;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "red")
        {
            // pManager.AddExp(Random.Range(50, 100), 10);
            GameObject battlePanel = (GameObject)Resources.Load ("Prefab/BattlePanel");
            GameObject battlePanelPrefab = (GameObject)Instantiate(battlePanel);
            battlePanelPrefab.transform.SetParent(canvas.transform, false);
        }
        if(other.gameObject.tag == "blue")
        {
            pManager.AddHP(20);
        }
        if(other.gameObject.tag == "gold")
        {
            pManager.AddMoney(500);
        }
        if(other.gameObject.tag == "silver")
        {
            pManager.AddPower(10, 100);
        }
    }
}