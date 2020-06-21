using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    public GameObject randomNumPanel;
    RandomManager randomManager;
    public GameObject moveBtnPanel;


    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        randomManager = randomNumPanel.GetComponent<RandomManager>();

    }

    void Update()
    {
        if(randomManager.GetNum() > 0)
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
            moveBtnPanel.SetActive(true);  
        }else if(playerController.GetIsBattle())
        {
            moveBtnPanel.SetActive(true);  
        }
        else 
        {
            player.GetComponent<BoxCollider2D>().enabled = true;   
            moveBtnPanel.SetActive(false);        
        }
    }
}
