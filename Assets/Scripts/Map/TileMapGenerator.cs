using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGenerator : MonoBehaviour
{
    //mapサイズ
    public int mapWidth = 10;
    public int mapHeight = 10;
    public int[,] map;

    //tile色
    public int white = 0;
    public int red = 1;

    //tileオブジェクト取得
    [SerializeField] public TileBase tile;
    [SerializeField] public GameObject tilemapObj;
    Tilemap tilemap;

    void Start()
    {
        tilemap = tilemapObj.GetComponent<Tilemap>();

        SetTileMapData();
        CreateMap();
    }

    /// <summary>
    /// mapの2次元配列初期化
    /// </summary>
    private void SetTileMapData()
    {
        map = new int[mapHeight, mapWidth];
        for(int i = 0; i < mapHeight; i++)
        {
            for(int j = 0; j < mapWidth; j++)
            {
                map[i, j] = white;
            }
        }
    }

    /// <summary>
    /// mapdataをもとにタイル配置
    /// </summary>
    private void CreateMap()
    {
        for(int i = 0; i < mapHeight; i++)
        {
            for(int j = 0; j < mapWidth; j++)
            {
                if(map[i, j] == white)
                {
                    Vector3Int pos = new Vector3Int(j, i, 0);
                    tilemap.SetTile(pos, tile);
                }
            }
        }
    }
}
