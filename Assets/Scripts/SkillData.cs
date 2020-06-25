using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : MonoBehaviour
{
    [SerializeField] public List<SkillBase> skill = new List<SkillBase>();

    private void Awake() {
        DontDestroyOnLoad(this);    
    }
    void Start()
    {
        skill.Add(new SkillBase("パンチ", 10, 1, "こぶしで殴りつける。", "Punch"));
        // skill.Add(new SkillBase("キック", 15, 1, "思いっきり蹴りとばす。","Kick"));
        // skill.Add(new SkillBase("スラッシュ", 30, 2, "鉄のつるぎで斬りつける。", "Slash"));
    }

}