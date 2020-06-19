using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNormalManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            // Debug.Log("Enter:ノーマルパネル");
        }
    }
}
