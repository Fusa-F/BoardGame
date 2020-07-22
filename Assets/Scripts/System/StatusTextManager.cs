using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusTextManager : MonoBehaviour
{
    public Text text;

    private void Awake()
    {
        text = this.gameObject.GetComponent<Text>();
    }
    
    public void SetText(string txt)
    {
        text.text = txt;
    }
    public void SetLevel(string txt)
    {
        text.text = "Lv." + txt;
    }
    public void SetPower(string txt)
    {
        text.text = "Power:" + txt;
    }
    public void SetMoney(string txt)
    {
        text.text = txt + "G";
    }
}
