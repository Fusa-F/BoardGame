using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    public EnemyManager status;
    [SerializeField] public bool isBoss;

    ///<summary>
    ///オブジェクト生成時に外部からSET
    ///</summary>
    public void SetStatus(EnemyManager data)
    {
        status = data;
    }
    public EnemyManager GetStatus()
    {
        return status;
    }
}
