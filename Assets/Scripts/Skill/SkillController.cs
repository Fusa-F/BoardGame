using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillController : MonoBehaviour
{
    //射程距離
    [SerializeField]public Vector3 distance = new Vector3(0f, 5f, 0f);
    //速度
    [SerializeField]public float speed = 1f;

    [SerializeField]public Vector3 target;

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    void Start()
    {
        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();

        StartCoroutine(MoveObject());
    }

    public IEnumerator MoveObject()
    {

        // Vector2 line = distance - pos;
        // transform.DOLocalMove(distance, speed).SetRelative().OnComplete(()=>
        // {
        //     Destroy(transform.parent.gameObject);
        // });
        transform.DOMove(target, speed).OnComplete(()=>
        {
            Destroy(transform.parent.gameObject);
        });
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            cameraController.ShakeCamera();
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
        }
    }

    //親よりターゲット座標セット
    public void SetPos(Vector3 pos)
    {
        target = pos;
    }
}
