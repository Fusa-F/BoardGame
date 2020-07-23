using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObjectController : MonoBehaviour
{
    public BoxCollider2D col;
    void Start()
    {
        col = this.gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false;
    }

    ///<summmary>
    ///スキルオブジェクトの当たり判定コライダーをセット
    ///</summary>
    public void SetCollider()
    {
        if(col.enabled)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
    }
}
