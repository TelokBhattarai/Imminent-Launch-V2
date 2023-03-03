using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BibekWFCAgainAgain : MonoBehaviour
{
    public BibekGenerator gen = new BibekGenerator(100, 20);
    public Tilemap bruhTilemap;
    public List<Tile> bruhTiles = new List<Tile>();
    public Tile t;
    public Tile b;
    public Tile vh;
    public Tile hh;
    public Tile tr;
    public Tile tl;
    public Tile br;
    public Tile bl;
    public Tile l;
    public Tile r;
    public Tile g;
    // Start is called before the first frame update
    void Start()
    {
        bruhTiles.Add(t);
        bruhTiles.Add(b);
        bruhTiles.Add(vh);
        bruhTiles.Add(hh);
        bruhTiles.Add(tr);
        bruhTiles.Add(tl);
        bruhTiles.Add(br);
        bruhTiles.Add(bl);
        bruhTiles.Add(l);
        bruhTiles.Add(r);
        bruhTiles.Add(g);

        gen.PerformWFC();
        Setup();

        bruhTilemap.SetTile(new Vector3Int(0,0,-10), bruhTiles[0]);

    }

    void Setup()
    {
        bruhTilemap.ClearAllTiles();
        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                // int rand = Random.Range(0, bruhTiles.Count);
                Vector3Int pos = new Vector3Int(x, y, -10);
                
                if (gen.stringMap[x, y] == "top")
                {
                    Debug.Log("valid top");
                    bruhTilemap.SetTile(pos, bruhTiles[0]);
                }
                else if (gen.stringMap[x, y] == "bottom")
                {
                    Debug.Log("valid top");
                    bruhTilemap.SetTile(pos, bruhTiles[1]);
                }
                else if (gen.stringMap[x, y] == "vertical")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[2]);
                }
                else if (gen.stringMap[x, y] == "horizontal")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[3]);
                }
                else if (gen.stringMap[x, y] == "topRight")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[4]);
                }
                else if (gen.stringMap[x, y] == "topLeft")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[5]);
                }
                else if (gen.stringMap[x, y] == "bottomRight")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[6]);
                }
                else if (gen.stringMap[x, y] == "bottomLeft")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[7]);
                }
                else if (gen.stringMap[x, y] == "left")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[8]);
                }
                else if (gen.stringMap[x, y] == "right")
                {
                    bruhTilemap.SetTile(pos, bruhTiles[9]);
                }
                else
                {
                    bruhTilemap.SetTile(pos, bruhTiles[10]);
                }

                
            }
        }

    }
}
