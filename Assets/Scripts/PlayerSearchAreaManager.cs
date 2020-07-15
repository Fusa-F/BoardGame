using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSearchAreaManager : MonoBehaviour
{
    public Button moveBtn;
    public GameObject gameManager;
    GManager gManager;

    void Start()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        gManager = gameManager.GetComponent<GManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            moveBtn.interactable = false;   
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            moveBtn.interactable = true;   
        }        
    }
}
