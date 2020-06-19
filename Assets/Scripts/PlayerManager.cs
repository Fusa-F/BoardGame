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

    public GameObject textPanel;
    TextManager textManager;

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

        textManager = textPanel.GetComponent<TextManager>();
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
        textManager.SetText("レベルアップ!\n" + "Lv." + level.ToString() + "になった!");
        level++;
    }
    public void AddHP(int cure)
    {
        textManager.SetText(cure.ToString() + "かいふく");
        if(hp + cure > maxHP)
        {
            int diff = (hp + cure) - maxHP;
            hp += cure - diff;
            return;
        }
        hp += cure;
    }
    public void SubHP(int damage)
    {
        textManager.SetText(damage.ToString() + "ダメージ");
        hp -= damage;
    }
    public void AddExp(int ex)
    {
        if(exp + ex >= maxExp)
        {
            int diff = (exp + ex) - maxExp;
            exp = 0;
            AddLevel();
            AddExp(diff);
        }else
        {
            exp += ex;
        }
    }
    public void AddMoney(int gold)
    {
        textManager.SetText(gold.ToString() + "Gひろった！");
        money += gold;
    }
    public void AddPower(int pow, int gold)
    {
        if(money >= gold)
        {
            textManager.SetText(gold.ToString() + "Gで" + pow.ToString() + "パワーをえた！");                
            power += pow;
            money -= gold;
        }else
        {
            textManager.SetText(gold.ToString() + "Gもってないのでなにもなし...");                
        }
    }
}
