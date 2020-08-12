using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillInstantiater : MonoBehaviour
{
    //スキル管理スクリプト
    PlayerSkillManager psManager;

    PlayerColliderManager colliderManager;

    //スキル生成時の親
    public GameObject player;

    private void Start()
    {
        psManager = this.GetComponent<PlayerSkillManager>();
        colliderManager = this.GetComponent<PlayerColliderManager>();
    }

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
            //スキルオブジェクト生成・コンポーネント取得
            // GameObject skillObj = (GameObject)Instantiate(psManager.skillList[0], pos, Quaternion.identity);

            if(colliderManager.targetList.Count > 0)
            {
                GameObject skillObj = (GameObject)Instantiate(psManager.skillList[0], pos, Quaternion.identity, player.transform);
                SkillDirectionManager sdManager = skillObj.GetComponent<SkillDirectionManager>();
                sdManager.SetTarget(colliderManager.targetList[0]);
            }

            yield return null;
        }
    }
}
