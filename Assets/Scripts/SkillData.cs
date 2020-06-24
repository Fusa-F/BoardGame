using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(this);    
    }
    void Start()
    {
        Dictionary<int, SkillBase> skill = new Dictionary<int, SkillBase>();

        skill[0] = new SkillBase("パンチ", 10, 1, "こぶしで殴りつける。");
        skill[1] = new SkillBase("キック", 15, 1, "思いっきり蹴りとばす。");
        skill[2] = new SkillBase("スラッシュ", 30, 2, "鉄のつるぎで斬りつける。");

        foreach (var key in skill.Keys)
        {
            Debug.Log(key + ":" + skill[key].name + ":" + skill[key].damage + ":" + skill[key].rarity + ":" + skill[key].caption);
        }
    }

    private class SkillBase {
        public string name;
        public int damage;
        public int rarity;
        public string caption;

        public SkillBase(string name, int damage, int rarity, string caption)
        {
            this.name = name;
            this.damage = damage;
            this.rarity = rarity;
            this.caption = caption;
        }
    }
}