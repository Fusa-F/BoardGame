﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillInstantiater : MonoBehaviour
{
    //プレイヤー位置
    public Vector2 pos;

    //スキル管理スクリプト
    PlayerSkillManager psManager;

    void Start()
    {
        psManager = this.gameObject.GetComponent<PlayerSkillManager>();
        Debug.Log("B -> PSInstantiater.InstantiateSkill()");
    }

    void FixedUpdate()
    {
        pos = transform.position;
        if(Input.GetKeyDown(KeyCode.B))
        {
            InstantiateSkill();
        }
    }

    public void InstantiateSkill()
    {
        if(psManager.skillList != null)
        {
            GameObject skillObj = (GameObject)Instantiate(psManager.skillList[0], pos, Quaternion.identity);
            skillObj.GetComponent<SkillController>().MoveObject();
        }
    }
}