using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    //プレイヤーの持つスキルのリスト
    public List<GameObject> skillList = new List<GameObject>();

    void Start()
    {
        
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
        GameObject obj = Instantiate(skillList[0], transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }
}
