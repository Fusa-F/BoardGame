using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status/Enemy")]
public class EnemyManager : ScriptableObject
{
    [SerializeField] public List<CharaStatus> enemyStatusList = new List<CharaStatus>();
}
