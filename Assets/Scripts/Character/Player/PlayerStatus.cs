using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public CharaStatus status;
    /*
    public string name;
    public int level;
    public int maxHp; 
    public int hp;
    public int maxExp;
    public int exp;
    public int power;
    public int money;
    */

    ///<summary>
    ///オブジェクト生成時に外部からSET
    ///</summary>
    public void SetStatus(CharaStatus data)
    {
        status = data;
    }
    public CharaStatus GetStatus()
    {
        return status;
    }
}
