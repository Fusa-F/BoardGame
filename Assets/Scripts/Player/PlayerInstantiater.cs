﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiater : MonoBehaviour
{
    public GameObject playerObj;

    //camera
    private GameObject cameraObj;
    CameraController cameraController;

    void Start()
    {
        playerObj = (GameObject)Resources.Load("Prefab/PlayerChara");

        //camera取得
        cameraObj = Camera.main.gameObject;
        cameraController = cameraObj.GetComponent<CameraController>();
    }

    void Update()
    {
        
    }

    public void InstantiatePlayer()
    {
        int rndX = Random.Range(1, 11);
        int rndY = Random.Range(1, 11);
        GameObject player = (GameObject)Instantiate(playerObj, new Vector2(rndX, rndY), Quaternion.identity);

        // ・移動メソッド呼び出し     
        cameraController.SetTarget(player);
    }
}