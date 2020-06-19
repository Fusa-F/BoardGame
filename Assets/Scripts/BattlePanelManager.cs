using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattlePanelManager : MonoBehaviour
{
    public GameObject playerController;
    PlayerController pController;
    BoxCollider2D boxCollider;
    public GameObject playerManager;
    PlayerManager pManager;

    private RectTransform rect;

    public Vector2 currentPos;
    public Vector2 battlePos = new Vector2(0, -2);

    GameObject battleGridPrefab;
    GameObject enemyPrefab;

    void Start()
    {
        playerController = GameObject.Find("Player");
        pController = playerController.GetComponent<PlayerController>();
        boxCollider = playerController.GetComponent<BoxCollider2D>();
        playerManager = GameObject.Find("Player/PlayerManager");
        pManager = playerManager.GetComponent<PlayerManager>();

        //プレイヤー元位置保存
        currentPos = pController.GetMove();
        pController.SetIsBattle(true);
        //プレイヤー表示位置・レイヤー設定
        pController.SetMove(battlePos);
        playerController.GetComponent<SpriteRenderer>().sortingLayerName = "BattleField";
        playerController.transform.DOLocalMove(battlePos, 1f);

        //グリッド・敵生成
        GameObject battleGrid = (GameObject)Resources.Load("Prefab/BattleGrid");
        battleGridPrefab = (GameObject)Instantiate(battleGrid);
        GameObject enemy = (GameObject)Resources.Load("Prefab/Enemy");
        enemyPrefab = (GameObject)Instantiate(enemy);

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

    public void EndBattle()
    {
        pController.SetIsBattle(false);
        //プレイヤー表示位置・レイヤー設定
        pController.SetMove(currentPos);
        playerController.transform.DOLocalMove(currentPos, 1f);
        Destroy(this.gameObject, 1f);
        Destroy(battleGridPrefab, 1f);
        Destroy(enemyPrefab, 1f);
    }
}
