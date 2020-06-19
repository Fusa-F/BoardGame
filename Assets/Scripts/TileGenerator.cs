using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] public Grid grid;
    [SerializeField] public TileBase tile;
    [SerializeField] public TileBase tileSec;
    [SerializeField] Vector3Int pos = new Vector3Int(0, 0, 0);

    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        for(int i=0; i<6; i++)
        {
            Vector3Int posFor = new Vector3Int(i, 0, 0);
            Vector3Int posForSec = new Vector3Int(0, i, 0);
            tilemap.SetTile(posFor, tile);
            tilemap.SetTile(posForSec, tileSec);
        }
    }

    void Update()
    {
        
    }
}
