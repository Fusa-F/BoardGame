using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSearchAreaManager : MonoBehaviour
{
    public bool isWall = false;

    void Start()
    {
    }

    //MoveBtnPanelManagerにて、MoveBtnManagerに渡す
    public bool GetIsWall()
    {
        return isWall;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Wall")
        {
            isWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Wall")
        {
            isWall = false;
        }        
    }
}
