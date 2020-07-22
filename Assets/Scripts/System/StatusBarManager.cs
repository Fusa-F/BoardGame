using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StatusBarManager : MonoBehaviour
{
    public Slider slider;
    public Text text;

    private void Awake()
    {
        slider = this.gameObject.GetComponent<Slider>();
        GameObject barText = this.gameObject.transform.Find("BarText").gameObject;
        text = barText.GetComponent<Text>();
    }
    
    public void SetValue(int cr, int mx)
    {
        slider.maxValue = mx;
        slider.value = (float)cr;
        text.text = cr + "/" + mx;
    }

}
