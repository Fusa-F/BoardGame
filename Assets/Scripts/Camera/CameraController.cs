using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    public GameObject target;
    void Start()
    {
        
    }

    void Update()
    {
        MoveCamera();
    }

    public void SetTarget(GameObject obj)
    {
        offsetX = transform.position.x - obj.transform.position.x;
        offsetY = transform.position.y - obj.transform.position.y;
        target = obj;
    }
    public void MoveCamera()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }
}
