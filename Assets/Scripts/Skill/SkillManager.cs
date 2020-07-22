using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{  
    void Start()
    {
        
    }

    void Update()
    {
        //test
        if(GameManager.Instance.currentState == GameState.Battle)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
