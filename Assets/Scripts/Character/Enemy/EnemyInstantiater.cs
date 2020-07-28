using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiater : MonoBehaviour
{
    //Enemyオブジェクト
    public List<GameObject> enemyObj = new List<GameObject>();

    void Start()
    {
        enemyObj.Add((GameObject)Resources.Load("Prefab/EnemyChara"));

    }

    ///<summery>
    ///エネミー生成
    ///</summery>
    public void InstantiateEnemy(Vector3Int pos)
    {
        int rndX = Random.Range(1, 11);
        int rndY = Random.Range(1, 11);

        foreach (GameObject enemyPre in enemyObj)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPre, new Vector2(pos.x, pos.y), Quaternion.identity);

            // //移動メソッド呼び出し     
            // cameraController.SetTarget(enemy);
            
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
