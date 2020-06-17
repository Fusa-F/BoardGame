using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattlePanelManager : MonoBehaviour
{
    public GameObject playerManager;
    PlayerManager pManager;

    private RectTransform rect;

    void Start()
    {
        playerManager = GameObject.Find("Player/PlayerManager");
        pManager = playerManager.GetComponent<PlayerManager>();

        rect = GetComponent<RectTransform>();
        // rect.DOScale(new Vector2(1.1f, 1.1f), 1f);
    }

    void Update()
    {
        
    }

    public void BattleAttack()
    {
        Debug.Log("a");
    }
    public void BattleTalk()
    {
        Debug.Log("b");
    }
    public void BattleExit()
    {
        Destroy(this.gameObject);
    }
}
