using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackManager : MonoBehaviour
{
    [SerializeField] public Dictionary<string, Skill> skill = new Dictionary<string, Skill>();
    void Start()
    {
        skill["パンチ"] = new Skill(10, 1, "こぶしで殴りつける。");
        skill["キック"] = new Skill(15, 1, "思いっきり蹴りとばす。");
        skill["スラッシュ"] = new Skill(30, 2, "鉄のつるぎで斬りつける。");

        foreach (var key in skill.Keys)
        {
            Debug.Log(key + ":" + skill[key].damage + ":" + skill[key].rarity + ":" + skill[key].caption);
        }
    }

    private class Skill {
        public int damage;
        public int rarity;
        public string caption;

        public Skill(int damage, int rarity, string caption)
        {
            this.damage = damage;
            this.rarity = rarity;
            this.caption = caption;
        }
    }
}