using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGenerator : MonoBehaviour
{
    //mapサイズ
    [SerializeField] public int mapWidth = 10;
    [SerializeField] public int mapHeight = 10;
    public int[,] map;

    //tile色
    public int white = 0;
    public int red = 1;
    public int blue = 2;
    public int gold = 3;
    public int silver = 4;
    public int black = 5;

    //tileオブジェクト取得
    [SerializeField] public TileBase tile;
    [SerializeField] public GameObject tilemapObj;
    private Tilemap tilemap;

    void Start()
    {
        //tilemapクラス取得
        tilemap = tilemapObj.GetComponent<Tilemap>();

        //初期化・配置メソッド
        SetTileMapData();
    }

    /// <summary>
    /// mapの2次元配列初期化
    /// </summary>
    public void SetTileMapData()
    {
        map = new int[mapHeight, mapWidth];
        for(int i = 0; i < mapHeight; i++)
        {
            for(int j = 0; j < mapWidth; j++)
            {
                if(ProbabilityCalclator.Probability(3))
                {
                    map[i, j] = red;
                }
                // else if(ProbabilityCalclator.Probability(5))
                // {
                //     map[i, j] = red;
                // }
                else
                {
                    map[i, j] = white;
                }
            }
        }

        CreateMap();
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
                    tilemap.SetTileFlags(pos, TileFlags.None);
                    tilemap.SetColor(pos, Color.white);
                }
                if(map[i, j] == red)
                {
                    Vector3Int pos = new Vector3Int(j, i, 0);
                    tilemap.SetTile(pos, tile);
                    tilemap.SetTileFlags(pos, TileFlags.None);
                    tilemap.SetColor(pos, Color.red);
                }
            }
        }
    }
}
