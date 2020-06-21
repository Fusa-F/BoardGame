using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomManager : MonoBehaviour
{
    public int num = 0;
    public Text randomNumText;

    public GameObject textPanel;
    TextManager textManager;

    void Start()
    {
        textManager = textPanel.GetComponent<TextManager>();
    }

    void FixedUpdate()
    {
        if(num > 0)
        {
            textManager.SetText("のこり" + num.ToString() + "歩動けるわ");
        }else
        {
            
        }
    }

    public int RandomNum()
    {
        return Random.Range(1, 11);
    }

    public void RandomBtn()
    {
        num = RandomNum();
        randomNumText.text = num.ToString();
    }

    public void SubRandomNum(int n)
    {
        num -= n;
    }

    public int GetNum()
    {
        return num;
    }
}
