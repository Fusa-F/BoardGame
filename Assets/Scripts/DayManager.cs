using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public int day = 21;
    public Text dayText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SubDay()
    {
        day--;
    }
}
