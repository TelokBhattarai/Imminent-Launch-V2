using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawning : MonoBehaviour
{
    public GameObject Enemy1;
    public float spawnTime = 0.5f;
    public float enemy1PerSpawn = 1f;
    public Tilemap tileMap;
    public List<Vector3> availablePlaces;




    private void Start()
    {
        
        availablePlaces = new List<Vector3>();

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
                Vector3 place = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
                {
                    availablePlaces.Add(place);
                }
            }
        }


        if (Enemy1 != null)
        {
            StartCoroutine("SpawnEnemy1");
        }
    }

    IEnumerator SpawnEnemy1()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            for (int i = 0; i < enemy1PerSpawn; i++)
            {
                Instantiate(Enemy1,
                     availablePlaces[Random.Range(0, availablePlaces.Count)],
                     Quaternion.identity);
            }

        }
    }
}
