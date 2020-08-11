using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{
    PlayerStatus pStatus;

    void Start()
    {
        pStatus = this.GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log(other.tag);
        }
    }
}
