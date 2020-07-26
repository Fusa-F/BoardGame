using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiater : MonoBehaviour
{
    //static変数(EnemyInstantiater.enemyInstで呼び出し可)
    public static EnemyInstantiater enemyInst;

    //Enemyオブジェクト
    public List<GameObject> enemyObj = new List<GameObject>();

    void Awake()
    {
        if(enemyInst == null)
        {
            enemyInst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        enemyObj.Add((GameObject)Resources.Load("Prefab/EnemyChara"));

    }

    ///<summery>
    ///エネミー生成
    ///</summery>
    public void InstantiateEnemy()
    {
        int rndX = Random.Range(1, 11);
        int rndY = Random.Range(1, 11);

        foreach (GameObject enemyPre in enemyObj)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPre, new Vector2(rndX, rndY), Quaternion.identity);

            // //移動メソッド呼び出し     
            // cameraController.SetTarget(enemy);
            
        }
    }
}
