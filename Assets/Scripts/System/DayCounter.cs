using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    public int day = 1;

    public GameObject textObj;
    Text text;
    
    void Start()
    {
        text = textObj.GetComponent<Text>();
    }

    public void CountUp(int num)
    {
        day += num;
        SetText();
    }

    private void SetText()
    {
        text.text = day.ToString() + " 日目";
    }
}
