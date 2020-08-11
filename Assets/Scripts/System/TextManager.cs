using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour 
{
    //TextManager.textManager
    public static TextManager textManager;

    [Header("履歴テキスト")][SerializeField] public List<string> messageList = new List<string>();
    [Header("履歴保存数")][SerializeField] public int messageListLength = 5;
    [SerializeField] public Text text;
    [SerializeField] public float speed;//一文字一文字の表示する速さ

    void Awake()
    {
        if(textManager == null)
        {
            textManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator TextCoroutine(string txt)
    {
        int messageCount = 0; //現在表示中の文字数
        text.text = ""; //テキストのリセット

        //文字をすべて表示するまで
        while(txt.Length > messageCount)
        {
            text.text += txt[messageCount];//一文字追加
            messageCount++;
            yield return new WaitForSeconds(speed);//任意の時間待つ
        }

        messageList.Add(txt);
        if(messageList.Count > messageListLength)
        {
            messageList.RemoveAt(0);
        }
        foreach (string item in messageList)
        {
            Debug.Log(item);
        }     
    }

    public void SetText(string txt)
    {

    }
}