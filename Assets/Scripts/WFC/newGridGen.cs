using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class newGridGen : MonoBehaviour
{
    UnityEngine.Grid gameGrid;
    UnityEngine.Tilemaps.Tilemap tmap;

    public UnityEngine.Tilemaps.Tile blankImg;
    public UnityEngine.Tilemaps.Tile upImg;
    public UnityEngine.Tilemaps.Tile rightImg;
    public UnityEngine.Tilemaps.Tile downImg;
    public UnityEngine.Tilemaps.Tile leftImg;

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = new GameObject("Tile Grid").AddComponent<Grid>();
        tmap = new GameObject("Tilemap").AddComponent<Tilemap>();
        tmap.transform.SetParent(gameGrid.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < ; i++)
        //{

        //}
        
    }
}
