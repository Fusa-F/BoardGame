using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObjectMover : MonoBehaviour
{
    public List<GameObject> obj = new List<GameObject>();
    private void Awake() {
        //すべての子要素オブジェクトの取得
        foreach(Transform child in this.gameObject.transform)
        {
            obj.Add(child.gameObject);
        }        
    }
    void Start()
    {
        
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
            yield return new WaitForSeconds(.3f);
            Destroy(child);
        }        
        Destroy(this.gameObject);
    }
}
