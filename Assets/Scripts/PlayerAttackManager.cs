using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackManager : MonoBehaviour
{
    public enum Skill {
        Punch,
        Kick,
        Slash
    };
    [SerializeField] public Dictionary<Skill, int> skillDictionary = new Dictionary<Skill, int>();
    void Start()
    {
        skillDictionary[Skill.Punch] = 2;
        foreach(var skill in skillDictionary)
        {
            Debug.Log(skill.Key + ":" + GetNum(skill.Key));
        }
    }

    void Update()
    {
        
    }

    public int GetNum(Skill key)
    {
        return skillDictionary[key];
    }
}
