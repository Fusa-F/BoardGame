using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaStatus
{
    [SerializeField]
    public string name;
    public int level;
    public int maxHp; 
    public int hp;
    public int maxExp;
    public int exp;
    public int power;
    public int money;

    public CharaStatus(string name, int level, int maxHp, int maxExp, int power, int money)
    {
        this.name = name;
        this.level = level;
        this.maxHp = maxHp;
        this.hp = maxHp;
        this.maxExp = maxExp;
        this.exp = 0;
        this.power = power;
        this.money = money;
    }
}
