using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillInstantiater : MonoBehaviour
{
    //スキル管理スクリプト
    PlayerSkillManager psManager;

    //CharaController内にて移動処理ごとに呼び出し
    public IEnumerator InstantiateSkill(Vector2 pos)
    {
        //test
        if(psManager == null)
        {
            psManager = this.gameObject.GetComponent<PlayerSkillManager>();
        }

        if(psManager.skillList != null)
        {
            GameObject skillObj = (GameObject)Instantiate(psManager.skillList[0], pos, Quaternion.identity);
            yield return null;
        }
    }
}
