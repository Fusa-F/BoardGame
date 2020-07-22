using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public CharaStatus status;

    public List<GameObject> uiObj = new List<GameObject>();

    void Start()
    {
        StartCoroutine("PlayerStatusSetUp");
    }

    void Update()
    {
    }

    public IEnumerator PlayerStatusSetUp()
    {
        //生成されステータスがSETされるまで待機
        while(status == null)
        {
            yield return null;
        }
        SetUIObject();
    }

    ///<summary>
    ///オブジェクト生成時に外部からSET
    ///</summary>
    public void SetStatus(CharaStatus data)
    {
        status = data;
    }

    ///<summary>
    ///UIオブジェクトの取得・値の受け渡し
    ///</summary>
    public void SetUIObject()
    {
        string pass = "Canvas/PlayerStatusPanel(Clone)";
        uiObj.Add(GameObject.Find(pass + "/PlayerName"));
        uiObj.Add(GameObject.Find(pass + "/PlayerLv"));
        uiObj.Add(GameObject.Find(pass + "/PlayerHP"));
        uiObj.Add(GameObject.Find(pass + "/PlayerExp"));
        uiObj.Add(GameObject.Find(pass + "/PlayerSubStatusPanel/PlayerPowerText"));
        uiObj.Add(GameObject.Find(pass + "/PlayerSubStatusPanel/PlayerMoneyText"));

        uiObj[0].GetComponent<StatusTextManager>().SetText(status.name.ToString());
        uiObj[1].GetComponent<StatusTextManager>().SetLevel(status.level.ToString());
        uiObj[2].GetComponent<StatusBarManager>().SetValue(status.hp, status.maxHp);
        uiObj[3].GetComponent<StatusBarManager>().SetValue(status.exp, status.maxExp);
        uiObj[4].GetComponent<StatusTextManager>().SetPower(status.power.ToString());
        uiObj[5].GetComponent<StatusTextManager>().SetMoney(status.money.ToString());
    }
}
