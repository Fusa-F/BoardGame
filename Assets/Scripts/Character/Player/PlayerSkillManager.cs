using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    //プレイヤーの持つスキルのリスト
    [Header("取得済みスキルリスト")]public List<GameObject> skillList = new List<GameObject>();

    void Start()
    {
        SetSkillList();
    }

    //test
    public void SetSkillList()
    {
        skillList.Add((GameObject)Resources.Load("Prefab/Skill/Skill_00"));
    }
}
