using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public GameObject target = null;
    void Start()
    {
        
    }

    void Update()
    {
        if(target != null)
        {
            MoveCamera();
        }
    }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }

    public void MoveCamera()
    {
        transform.DOLocalMove(new Vector3(target.transform.position.x, target.transform.position.y, -10), 1f);
    }

    public void ShakeCamera()
    {
        transform.DOShakePosition(.5f);
    }
}
