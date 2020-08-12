using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{
    // PlayerStatus pStatus;

    [SerializeField]public List<Vector3> targetList = new List<Vector3>();

    void Start()
    {
        // pStatus = this.GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            targetList.Add(other.gameObject.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            for(int i = 0; i < targetList.Count; i++)
            {
                if(other.gameObject.transform.position == targetList[i])
                {
                    targetList.RemoveAt(i);
                }
            }
        }        
    }
}
