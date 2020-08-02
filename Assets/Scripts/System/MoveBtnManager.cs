using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBtnManager : MonoBehaviour
{
    private Button btn;
    [SerializeField] public string direction = "";

    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
    }

    public void SetInteractable(bool isWall)
    {
        if(isWall)
        {
            btn.interactable = false;
        }  
        else
        {
            btn.interactable = true;
        }
        Debug.Log(direction + ":" + btn.interactable);
    }
}
