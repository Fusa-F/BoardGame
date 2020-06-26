using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Skill")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Searching")
        {
        }
        
    }
}
