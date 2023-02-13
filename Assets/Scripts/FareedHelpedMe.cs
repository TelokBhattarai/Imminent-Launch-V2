using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FareedHelpedMe : MonoBehaviour
{
    public Generator gen = new Generator(50, 20);
    public Tilemap bruhTilemap;
    public List<Tile> bruhTiles = new List<Tile>();
    public Vector3Int pos = new Vector3Int(0, 0, 0);
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
        foreach (Cell CELL in gen.grid)
        {
            pos = new Vector3Int(CELL.x, CELL.y, 0);
            if (CELL.options[0] == "blankKey")
            {
                bruhTilemap.SetTile(pos, bruhTiles[0]);
            }
            else if (CELL.options[0] == "upKey")
            {
                bruhTilemap.SetTile(pos, bruhTiles[1]);
            }
            else if (CELL.options[0] == "rightKey")
            {
                bruhTilemap.SetTile(pos, bruhTiles[2]);
            }
            else if (CELL.options[0] == "downKey")
            {
                bruhTilemap.SetTile(pos, bruhTiles[3]);
            }
            else if (CELL.options[0] == "leftKey")
            {
                bruhTilemap.SetTile(pos, bruhTiles[4]);
            }
        }
    }
}
