using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDirectionManager : MonoBehaviour
{
    public GameObject skill;
    SkillController skillController;

    void Start()
    {
    }

    void Update()
    {
        
    }

    ///<summary>
    ///PlayerSkillInstantiaterよりスキル生成時にターゲットのベクトルをセット
    ///</summary>
    public void SetTarget(Vector3 pos)
    {
        skillController = skill.GetComponent<SkillController>();
        Debug.Log(pos);
        skillController.SetPos(pos);
    }
}
