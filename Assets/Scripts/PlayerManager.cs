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

    void FixedUpdate()
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
    public void NoneAdd()
    {
        int rnd = Random.Range(0, 10);
        string txt = null;
        switch (rnd)
        {
            case 0:
                txt = "なにもなかったなぁ。";
                break;
            case 1:
                txt = "小腹がへってきたなぁ。";
                break;
            case 2:
                txt = "ちょっとねむいなぁ。";
                break;
            case 3:
                txt = "髪切ろうかなぁ。";
                break;
            case 4:
                txt = "爪伸びてきたなぁ。";
                break;
            case 5:
                txt = "家のカギ閉めたっけなぁ。";
                break;
            case 6:
                txt = "映画観たいなぁ。";
                break;
            case 7:
                txt = "カレー食いたいなぁ。";
                break;
            case 8:
                txt = "暑いなぁ。";
                break;
            case 9:
                txt = "腰痛いなぁ。";
                break;
        }
        textManager.SetText(pName + "「" + txt + "」\n");
    }
}
