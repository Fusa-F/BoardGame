using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObjectMover : MonoBehaviour
{
    //子要素オブジェクト格納リスト
    public List<GameObject> obj = new List<GameObject>();

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    private void Awake() {
        //すべての子要素オブジェクトの取得
        foreach(Transform child in this.gameObject.transform)
        {
            obj.Add(child.gameObject);
        }

        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();          
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            DoSkill();
        }
        
    }

    ///<summary>
    ///スキル発動時の子要素オブジェクト生成メソッド
    ///</summary>
    public void DoSkill()
    {
        StartCoroutine("DoSkillCoroutine");
    }
    private IEnumerator DoSkillCoroutine()
    {
        foreach(GameObject child in obj)
        {
            child.GetComponent<SkillObjectController>().SetCollider();
            //camera振動
            cameraController.ShakeCamera();
            yield return new WaitForSeconds(.3f);
            Destroy(child);
        }        
        Destroy(this.gameObject);
    }
}
