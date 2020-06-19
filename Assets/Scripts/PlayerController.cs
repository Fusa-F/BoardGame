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
    public GameObject battlePanelPrefab;
    BattlePanelManager bpManager;

    public bool isBattle = false;
    public bool endBattle = false;

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

        if(endBattle)
        {
            endBattle = false;
        }
        return sequence;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!isBattle)
        {
            if(other.gameObject.tag == "red" && !endBattle)
            {
                GameObject battlePanel = (GameObject)Resources.Load ("Prefab/BattlePanel");
                battlePanelPrefab = (GameObject)Instantiate(battlePanel);
                battlePanelPrefab.transform.SetParent(canvas.transform, false);
                bpManager = battlePanelPrefab.GetComponent<BattlePanelManager>();
            }
            if(other.gameObject.tag == "blue")
            {
                int cure = Random.Range(20, 80);
                pManager.AddHP(cure);
            }
            if(other.gameObject.tag == "gold")
            {
                int g = Random.Range(100, 500);
                pManager.AddMoney(g);
            }
            if(other.gameObject.tag == "silver")
            {
                int g = Random.Range(50, 300);
                int p = Random.Range(100, 500);
                pManager.AddPower(g, p);
            }
        }else
        {
            if(other.gameObject.tag == "BattleField")
            {
                Debug.Log("Enter:BF");
            }
            if(other.gameObject.tag == "Exit")
            {
                endBattle = true;
                bpManager.EndBattle();
                Debug.Log("Enter:Exit");
            }     
            if(other.gameObject.tag == "Enemy")
            {
                Debug.Log("ENEMY!");
                pManager.AddExp(10);
                pManager.SubHP(Random.Range(20, 50));
                Destroy(other.gameObject);
            }      
        }
    }

    public Vector2 GetMove()
    {
        return this.move;
    }

    public void SetMove(Vector2 pos)
    {
        this.move = pos;
    }

    public void SetIsBattle(bool tf)
    {
        this.isBattle = tf;
    }

    public void SetEndBattle(bool tf)
    {
        this.endBattle = tf;
    }
}