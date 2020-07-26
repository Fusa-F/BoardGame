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

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    void Start()
    {
        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();

        MoveObject();
    }

    public void MoveObject()
    {
        // Vector2 line = distance - pos;
        transform.DOLocalMove(distance, speed).SetRelative().OnComplete(()=>
        {
            Destroy(transform.parent.gameObject);
        });
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            cameraController.ShakeCamera();
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}
