using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiater : MonoBehaviour
{
    //Enemyオブジェクト
    public GameObject enemyObj;
    public List<GameObject> enemyObjList = new List<GameObject>();

    //EnemyManagerステータス管理
    public EnemyManager enemyManager;

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    void Start()
    {
        enemyObj = (GameObject)Resources.Load("Prefab/EnemyChara");
        enemyManager = Resources.Load<EnemyManager>("Prefab/EnemyManager01");

        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();
    }

    ///<summery>
    ///エネミー生成
    ///</summery>
    public IEnumerator InstantiateEnemy(Vector3Int pos)
    {
        int x = pos.x + 1;
        int y = pos.y + 1;
        Vector2 position = new Vector2(x, y);
        Quaternion rote = Quaternion.Euler(0f, 0f, 45f);

        GameObject enemy = (GameObject)Instantiate(enemyObj, position, rote);
        enemyObjList.Add(enemy);
        SetEnemyStatus(enemy);

        //移動メソッド呼び出し     
        cameraController.SetTarget(enemy);
        yield return new WaitForSeconds(2f);
    }
    ///<summary>
    ///redタイル座標にエネミー生成
    ///</summary>
    public IEnumerator SummonEnemyRedTile()
    {
        int redTileCount = TileMapGenerator.tileGen.redTileList.Count - 1;
        int rnd = Random.Range(0, redTileCount);
        yield return StartCoroutine(InstantiateEnemy(TileMapGenerator.tileGen.redTileList[rnd]));
        Debug.Log(rnd);
    }

    ///<summery>
    ///エネミー情報入力
    //別途クラス用意検討
    ///</summery>
    public void SetEnemyStatus(GameObject e)
    {
        //ランダムなエネミー情報を取得・生成
        int rnd = Random.Range(0, enemyManager.enemyStatusList.Count);
        CharaStatus status = enemyManager.enemyStatusList[rnd];
        EnemyStatus enemyStatus = e.GetComponent<EnemyStatus>();
        enemyStatus.SetStatus(status, enemyObjList.Count - 1);
    }
}
