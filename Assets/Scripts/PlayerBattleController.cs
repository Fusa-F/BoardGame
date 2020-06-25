using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleController : MonoBehaviour
{
    public GameObject playerAttackManager;
    PlayerAttackManager pAttackManager;

    public List<GameObject> areaPrefab = new List<GameObject>();
    void Start()
    {
        pAttackManager = playerAttackManager.GetComponent<PlayerAttackManager>();
    }

    void Update()
    {
        
    }

    public void AtackBtn()
    {    
        areaPrefab.Add(pAttackManager.GetSkillArea(0));
        Instantiate(areaPrefab[0], transform.position, Quaternion.identity);

        // for (int i = 0; i < areaPrefab.Count; i++)
        // {
        //     areaPrefab.Add((GameObject)pAttackManager.GetSkillArea(i));
        //     Instantiate(areaPrefab[i], transform.position, Quaternion.identity);
        // }

    }
}
