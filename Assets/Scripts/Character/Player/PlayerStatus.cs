using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public CharaStatus status;

    void Start()
    {
    }

    void Update()
    {
    }

    ///<summary>
    ///オブジェクト生成時に外部からSET
    ///</summary>
    public void SetStatus(CharaStatus data)
    {
        status = data;
    }
    public CharaStatus GetStatus()
    {
        return status;
    }
}
