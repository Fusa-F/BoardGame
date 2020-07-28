using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiater : MonoBehaviour
{
    //Enemyオブジェクト
    public List<GameObject> enemyObj = new List<GameObject>();

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    void Start()
    {
        enemyObj.Add((GameObject)Resources.Load("Prefab/EnemyChara"));

        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();
    }

    ///<summery>
    ///エネミー生成
    ///</summery>
    public void InstantiateEnemy(Vector3Int pos)
    {
        int x = pos.x + 1;
        int y = pos.y + 1;

        foreach (GameObject enemyPre in enemyObj)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPre, new Vector2(x, y), Quaternion.identity);

            //移動メソッド呼び出し     
            cameraController.SetTarget(enemy);
            
        }
    }
    ///<summary>
    ///redタイル座標に確率でエネミー生成
    ///</summary>
    public void SummonEnemyRedTile()
    {
        int redTileCount = TileMapGenerator.tileGen.redTileList.Count - 1;
        int rnd = Random.Range(0, redTileCount);
        InstantiateEnemy(TileMapGenerator.tileGen.redTileList[rnd]);
        Debug.Log(rnd);
    }
}
