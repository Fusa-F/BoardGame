using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    //プレイヤーの持つスキルのリスト
    public List<GameObject> skillList = new List<GameObject>();

    void Start()
    {
        Debug.Log("X -> PlayerSkillManager.SetSkillList()");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            SetSkillList();
        }
    }

    //test
    public void SetSkillList()
    {
        skillList.Add((GameObject)Resources.Load("Prefab/Skill/Skill_00"));
    }
}
