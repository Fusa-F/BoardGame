using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///dropdownにアタッチ
///</summary>
public class PlayerNumberSelecter : MonoBehaviour
{
    public Dropdown dropdown;

    public List<string> list = new List<string>();
    void Start()
    {
        dropdown.ClearOptions();
        list = new List<string>();
        list.Add("1人");
        list.Add("2人");
        list.Add("3人");
        list.Add("4人");
        dropdown.AddOptions(list);
        dropdown.value = 0;
    }

    public void GetPlayerNumber()
    {
        Debug.Log(dropdown.value + 1 + "人");
    }
}
