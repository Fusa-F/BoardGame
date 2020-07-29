using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFlowManager : MonoBehaviour
{
    //mainscene オブジェクト
    public GameObject playerInstantiater;
    PlayerInstantiater pInst;

    private void Awake() {
        pInst = playerInstantiater.GetComponent<PlayerInstantiater>();
    }
    void Start()
    {
        StartCoroutine("MainFlow");
    }

    void Update()
    {
        
    }

    ///<summary>
    ///ゲームの流れを管理するコルーチン
    ///</summary>
    public IEnumerator MainFlow()
    {
        pInst.StartInstantiate();
        yield return null;
    }
}
