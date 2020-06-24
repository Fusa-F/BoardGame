using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackManager : MonoBehaviour
{
    [SerializeField] public Dictionary<string, SkillBase> skill = new Dictionary<string, SkillBase>();
    void Start()
    {
        skill["パンチ"] = new SkillBase(10, 1, "こぶしで殴りつける。");
        skill["キック"] = new SkillBase(15, 1, "思いっきり蹴りとばす。");
        skill["スラッシュ"] = new SkillBase(30, 2, "鉄のつるぎで斬りつける。");

        foreach (var key in skill.Keys)
        {
            Debug.Log(key + ":" + skill[key].damage + ":" + skill[key].rarity + ":" + skill[key].caption);
        }
    }

    private class SkillBase {
        public int damage;
        public int rarity;
        public string caption;

        public SkillBase(int damage, int rarity, string caption)
        {
            this.damage = damage;
            this.rarity = rarity;
            this.caption = caption;
        }
    }
}