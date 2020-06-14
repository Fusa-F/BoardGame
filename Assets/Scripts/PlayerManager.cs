using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //UI
    public Slider hpSlider;
    public Slider expSlider;
    public Text pNameText;
    public Text levelText;
    public Text hpText;
    public Text moneyText;
    public Text powerText;

    //Status
    [SerializeField] public string pName;
    [SerializeField] public int level;
    [SerializeField] public int maxHP;
    public int hp;
    [SerializeField] public int maxExp;
    public int exp;
    [SerializeField] public int money;
    [SerializeField] public int power;

    void Start()
    {
        //スライダーのセット
        hp = maxHP;
        hpSlider.maxValue = maxHP;
        exp = 0;
        expSlider.maxValue = maxExp;
    }

    void Update()
    {
        //テキストのセット・スライダーの更新
        pNameText.text = pName;
        levelText.text = "Lv." + level;
        hpText.text = hp + "/" + maxHP;
        hpSlider.value = hp;
        expSlider.value = exp;
        moneyText.text = "G:" + money;
        powerText.text = "POW:" + power;
    }

    public void AddLevel()
    {
    }
    public void AddHP(int cure)
    {
        if(hp + cure > maxHP)
        {
            int diff = (hp + cure) - maxHP;
            hp += cure - diff;
            return;
        }
        hp += cure;
    }
    public void AddExp(int ex, int damage)
    {
        if(exp + ex >= maxExp)
        {
            int diff = (exp + ex) - maxExp;
            exp = 0;
            level++;
            AddExp(diff, damage);
        }else
        {
            exp += ex;
            hp -= damage;
        }
    }
    public void AddMoney(int gold)
    {
        money += gold;
    }
    public void AddPower(int pow, int gold)
    {
        power += pow;
        money -= gold;
    }
}
