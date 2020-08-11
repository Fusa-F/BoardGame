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
    private int normal = 0;
    private int red = 1;
    private int blue = 2;
    private int gold = 3;
    private int silver = 4;
    private int black = 5;
    private int white = 6;
    [SerializeField] public List<Color> colorList = new List<Color>();

    //tileオブジェクト取得
    [SerializeField] public TileBase tile;
    [SerializeField] public TileBase tileWall;
    [SerializeField] public TileBase tileWt;
    //床
    [SerializeField] public GameObject tilemapObj;
    private Tilemap tilemap;
    //壁
    [SerializeField] public GameObject tilemapObjWall;
    private Tilemap tilemapWall;

    //各マス座標リスト
    public List<Vector3Int> redTileList = new List<Vector3Int>();
    public List<Vector3Int> blueTileList = new List<Vector3Int>();
    public List<Vector3Int> goldTileList = new List<Vector3Int>();
    public List<Vector3Int> silverTileList = new List<Vector3Int>();
    public List<Vector3Int> blackTileList = new List<Vector3Int>();
    public List<Vector3Int> whiteTileList = new List<Vector3Int>();

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
        tilemapWall = tilemapObjWall.GetComponent<Tilemap>();

        //初期化・配置メソッド
        SetTileMapData();
    }

    /// <summary>
    /// mapの2次元配列初期化
    /// </summary>
    public void SetTileMapData()
    {
        map = new int[mapHeight, mapWidth];
        //各タイルリスト初期化
        redTileList.Clear();
        blueTileList.Clear();
        goldTileList.Clear();
        silverTileList.Clear();
        blackTileList.Clear();
        whiteTileList.Clear();

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
                    map[i, j] = normal;
                }
            }
        }      

        //white(goal)タイルのランダム設置
        int rndX = Random.Range(0, mapHeight);
        int rndY = Random.Range(0, mapWidth);
        map[rndX, rndY] = white;

        //タイル配置
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
                SetColorTile(i, j, normal);
                SetColorTile(i, j, red);
                SetColorTile(i, j, blue);
                SetColorTile(i, j, gold);
                SetColorTile(i, j, silver);
                SetColorTile(i, j, black);
                SetColorTile(i, j, white);
            }
        }

        //壁配置
        SetWallTile();
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
            else if(colorNum == blue)
            {
                blueTileList.Add(pos);
            }
            else if(colorNum == gold)
            {
                goldTileList.Add(pos);
            }
            else if(colorNum == silver)
            {
                silverTileList.Add(pos);
            }
            else if(colorNum == black)
            {
                blackTileList.Add(pos);
            }
            else if(colorNum == white)
            {
                whiteTileList.Add(pos);
                tilemap.SetTile(pos, tileWt);
                tilemap.SetTileFlags(pos, TileFlags.None);
                tilemap.SetColor(pos, color);
            }
        }
    }
    /// <summary>
    /// 設定されたmapサイズから周囲に壁を設置
    /// </summary>
    public void SetWallTile()
    {
        int maxH = mapHeight + 1;
        int maxW = mapWidth + 1;

        for(int i = -1; i < maxH; i++)
        {
            for(int j = -1; j < maxW; j++)
            {
                if(i == -1 || i == mapHeight)
                {
                    Vector3Int pos = new Vector3Int(j, i, 0);
                    tilemapWall.SetTile(pos, tileWall);
                    tilemapWall.SetTileFlags(pos, TileFlags.None);
                }
                else
                {
                    if(j == -1 || j == mapWidth)
                    {
                        Vector3Int pos = new Vector3Int(j, i, 0);
                        tilemapWall.SetTile(pos, tileWall);
                        tilemapWall.SetTileFlags(pos, TileFlags.None);
                    }
                }
            }
        }
    }
}
