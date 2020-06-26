using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    public GameObject moveBtnPanel;
    public GameObject randomBtnPanel;

    public bool isBattle;
    public bool endBattle;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        StartCoroutine("SetBtn");
    }

    void Update()
    {
        
    }

    public IEnumerator SetBtn()
    {
        yield return new WaitForSeconds(3f);
        SearchPanelBtn(randomBtnPanel, false);
        yield return new WaitForSeconds(3f);
        SearchPanelBtn(randomBtnPanel, true);
    }

    public void SearchPanelBtn(GameObject panel, bool tf)
    {
        foreach(Transform btn in panel.transform)
        {
            btn.gameObject.GetComponent<Button>().interactable = tf;
        }
    }
}
