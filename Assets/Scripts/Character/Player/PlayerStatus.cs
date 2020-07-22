using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]public CharaStatus status;

    void Start()
    {

    }

    void Update()
    {
        if(status != null)
        {        Debug.Log(status.name);


        }
    }

    public void SetStatus(CharaStatus data)
    {
        status = data;
    }
}
