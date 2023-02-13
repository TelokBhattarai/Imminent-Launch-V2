using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WFCAgainAgain : MonoBehaviour
{
    public Generator gen = new Generator(50, 20);
    public Tilemap bruhTilemap;
    public List<Tile> bruhTiles = new List<Tile>();
    public Tile blankImg;
    public Tile upImg;
    public Tile rightImg;
    public Tile downImg;
    public Tile leftImg;
    // Start is called before the first frame update
    void Start()
    {
        bruhTiles.Add(blankImg);
        bruhTiles.Add(upImg);
        bruhTiles.Add(rightImg);
        bruhTiles.Add(downImg);
        bruhTiles.Add(leftImg);
        gen.PerformWFC();
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Setup()
    {
        bruhTilemap.ClearAllTiles();
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                // int rand = Random.Range(0, bruhTiles.Count);
                Vector3Int pos = new Vector3Int(x, y, -10);
                if (gen.stringMap[y, x] == "┴")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[1]);
                }
                else if (gen.stringMap[y, x] == "├")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[2]);
                }
                else if (gen.stringMap[y, x] == "┬")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[3]);
                }
                else if (gen.stringMap[y, x] == "┤")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[4]);
                }
                else
                {
                    bruhTilemap.SetTile(pos, bruhTiles[0]);
                }
            }
        }

    }
}
