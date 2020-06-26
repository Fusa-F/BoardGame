using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerBattleController : MonoBehaviour
{
    public GameObject playerAttackManager;
    PlayerAttackManager pAttackManager;
    public GameObject player;
    public GameObject textPanel;
    TextManager textManager;
    public bool isAttack = false;
    public Sequence areaSeq;

    public List<GameObject> areaPrefab = new List<GameObject>();
    public GameObject areaObj;
    void Start()
    {
        player = GameObject.Find("Player");
        playerAttackManager = GameObject.Find("PlayerAttackManager");
        textPanel = GameObject.Find("TextPanel");
        pAttackManager = playerAttackManager.GetComponent<PlayerAttackManager>();
        textManager = textPanel.GetComponent<TextManager>();
    }

    void Update()
    {
        
    }

    public void AtackBtn()
    {    
        if(!isAttack)
        {
            areaPrefab.Add(pAttackManager.GetSkillArea(0));
            areaObj = Instantiate(areaPrefab[0], playerAttackManager.transform.position, Quaternion.identity, playerAttackManager.transform);
            foreach(Transform child in areaObj.transform)
            {
                child.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            isAttack = true;
        }
        else{
            foreach(Transform child in areaObj.transform)
            {
                areaSeq = AreaObjSequence(child, areaObj.transform);
                areaSeq.Play();
            }
            isAttack = false;
        }
    }

    public Sequence AreaObjSequence(Transform obj, Transform parent)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(obj.DORotate(new Vector3(0f, 0f, 180f), .5f))
                .Append(obj.DOScale(new Vector2(.5f, .5f), .5f))
                .AppendCallback(()=>
                {
                    obj.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                })
                .Join(obj.DOScale(new Vector2(.8f, .8f), .2f))
                .AppendCallback(()=>
                {
                    Destroy(obj.gameObject);
                    Destroy(parent.gameObject);
                });
        return sequence;
    }
    public void TalkBtn()
    {
        textManager.SetText("〇とおはなしした");
    }
}
