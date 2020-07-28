using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TileMapGenerator : MonoBehaviour
{
    //static(TileMapGenerator.tile)
    public static TileMapGenerator tileGen;

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
    [SerializeField] public List<Color> colorList = new List<Color>();

    //tileオブジェクト取得
    [SerializeField] public TileBase tile;
    [SerializeField] public GameObject tilemapObj;
    private Tilemap tilemap;

    //redマス座標リスト
    public List<Vector3Int> redTileList = new List<Vector3Int>();

    void Awake()
    {
        if(tileGen == null)
        {
            tileGen = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

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
                if(ProbabilityCalclator.Probability(15))
                {
                    map[i, j] = red;
                }
                else if(ProbabilityCalclator.Probability(15))
                {
                    map[i, j] = blue;
                }
                else if(ProbabilityCalclator.Probability(10))
                {
                    map[i, j] = gold;
                }
                else if(ProbabilityCalclator.Probability(10))
                {
                    map[i, j] = silver;
                }
                else if(ProbabilityCalclator.Probability(5))
                {
                    map[i, j] = black;
                }
                else
                {
                    map[i, j] = white;
                }
            }
        }

        CreateMap();

        int num=0;
        //test
        foreach (Vector3Int r in redTileList)
        {
            Debug.Log(num + ":" + r);
            num++;
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
                SetColorTile(i, j, white);
                SetColorTile(i, j, red);
                SetColorTile(i, j, blue);
                SetColorTile(i, j, gold);
                SetColorTile(i, j, silver);
                SetColorTile(i, j, black);
            }
        }
    }
    /// <summary>
    /// 設定された各タイルデータに沿いタイル色を設定
    /// </summary>
    public void SetColorTile(int i, int j, int colorNum)
    {
        Color color = colorList[colorNum];
        if(map[i, j] == colorNum)
        {
            Vector3Int pos = new Vector3Int(j, i, 0);
            tilemap.SetTile(pos, tile);
            tilemap.SetTileFlags(pos, TileFlags.None);
            tilemap.SetColor(pos, color);

            if(colorNum == red)
            {
                redTileList.Add(pos);
            }
        }
    }
}
