using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillBase {
    public string name;
    public int damage;
    public int rarity;
    public string caption;
    public GameObject area;

    public SkillBase(string name, int damage, int rarity, string caption, string pass)
    {
        this.name = name;
        this.damage = damage;
        this.rarity = rarity;
        this.caption = caption;
        this.area = (GameObject)Resources.Load("Prefab/Skill/" + pass);
    }
}
