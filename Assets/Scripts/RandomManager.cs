using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomManager : MonoBehaviour
{
    public Text randomNumText;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public int RandomNum()
    {
        return Random.Range(1, 11);
    }

    public void RandomBtn()
    {
        randomNumText.text = RandomNum().ToString();
    }
}
