using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TouchInputManager
{
    private static Vector2 touchStartPos;
    private static Vector2 touchEndPos;

    public static void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            touchStartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)){
            touchEndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GetDirection();
        }
    }

    private static void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        string Direction = "";

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX)){
            if (30 < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if(-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
            else if(Mathf.Abs(directionX) < Mathf.Abs(directionY))
            {
                if(30 < directionY)
                {
                    //上向きにフリック
                    Direction = "up";
                }
                else if(-30 > directionY)
                {
                    //下向きのフリック
                    Direction = "down";
                }
            }
            else
            {
                //タッチを検出
                Direction = "touch";
            }
        }

        switch(Direction)
        {
            case "up":
                //上フリックされた時の処理
                Debug.Log("up");
                break;

            case "down":
                //下フリックされた時の処理
                Debug.Log("down");
                break;

            case "right":
                //右フリックされた時の処理
                Debug.Log("right");
                break;

            case "left":
                //左フリックされた時の処理
                Debug.Log("left");
                break;

            case "touch":
                //タッチされた時の処理
                Debug.Log("touch");
                break;
        }
    }
}
