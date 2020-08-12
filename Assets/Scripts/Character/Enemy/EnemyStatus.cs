using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    public CharaStatus status;
    /*
    public string name;
    public Sprite image;
    public int level;
    public int maxHp; 
    public int hp;
    public int maxExp;
    public int exp;
    public int power;
    public int money;
    */

    [SerializeField] public bool isBoss;
    [Header("何番目か")][SerializeField] public int listNum;

    GameObject enemyInstantiater;
    EnemyInstantiater eInst;

    private void Start()
    {
        enemyInstantiater = GameObject.Find("Instantiater/EnemyInstantiater");
        eInst = enemyInstantiater.GetComponent<EnemyInstantiater>();
    }
    private void OnDestroy()
    {
        for(int i = 0; i < eInst.enemyObjList.Count; i++)
        {
            EnemyStatus eStat = eInst.enemyObjList[i].GetComponent<EnemyStatus>();
            if(eStat.listNum == listNum)
            {
                eInst.enemyObjList.RemoveAt(i);
            }
        }
    }

    ///<summary>
    ///オブジェクト生成時に外部からSET
    ///</summary>
    public void SetStatus(CharaStatus data, int num)
    {
        status = data;
        listNum = num;
        SetSprite();
    }
    public CharaStatus GetStatus()
    {
        return status;
    }

    private void SetSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = status.image;
    }
}
