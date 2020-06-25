using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackManager : MonoBehaviour
{
    public GameObject skillData;
    SkillData sData;

    public List<SkillBase> playerAttack = new List<SkillBase>();
    void Start()
    {
        sData = skillData.GetComponent<SkillData>();
        Invoke("SetSkill", 1f);
    }

    public void SetSkill()
    {
        playerAttack.Add(sData.skill[0]);
        for (int i = 0; i < playerAttack.Count; i++)
        {
            Debug.Log(playerAttack[i].name);    
        }
    }

    public GameObject GetSkillArea(int num)
    {
        return playerAttack[num].area;
    }
}