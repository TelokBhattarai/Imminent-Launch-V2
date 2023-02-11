using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class testSCript : MonoBehaviour
{
    Generator gen;
    public UnityEngine.Tilemaps.Tile blank;
    public UnityEngine.Tilemaps.Tile up;
    public UnityEngine.Tilemaps.Tile right;
    public UnityEngine.Tilemaps.Tile down;
    public UnityEngine.Tilemaps.Tile left;
    // Start is called before the first frame update
    void Start()
    {
        gen = new Generator(50, 20);
        gen.blankImg = blank;
        gen.upImg = up;
        gen.rightImg = right;
        gen.downImg = down;
        gen.leftImg = left;
        gen.gameGrid = new GameObject("Tile Grid").AddComponent<Grid>();
        gen.tmap = new GameObject("Tilemap").AddComponent<Tilemap>();
        gen.tmap.transform.SetParent(gen.gameGrid.transform);
        gen.PerformWFC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
