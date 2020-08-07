using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
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

    ///<summary>
    ///オブジェクト生成時に外部からSET
    ///</summary>
    public void SetStatus(CharaStatus data)
    {
        status = data;
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
