using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public GameObject target = null;

    [Header("ズームイン")]
    public float defaultSize;
    [SerializeField] private float zoom = 15;
    [SerializeField] private float time = 1f;

    void Start()
    {
        defaultSize = Camera.main.orthographicSize;
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

    public void ZoomInCamera()
    {
        DOTween.To(
            () => Camera.main.orthographicSize,
            fov => Camera.main.orthographicSize = fov, zoom, time
        );
    }
    public void ZoomOutCamera()
    {
        DOTween.To(
            () => Camera.main.orthographicSize,
            fov => Camera.main.orthographicSize = fov, defaultSize, time
        );
    }
}
