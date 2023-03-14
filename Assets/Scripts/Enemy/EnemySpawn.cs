using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    
    public GameObject SlimePrefab;
    public GameObject OrcPrefab;
    
    public static int spawnLimit = 3;

    
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;


    public static List<GameObject> activeEnemies;

    public Transform player;   
    public float minDistance;  

    void Start()
    {
        // if the player has not been set in the inspector log it
        if (player == null)
        {
            Debug.LogWarning("EnemySpawn.Start(): There is no player set in the inspector. Please set.");
        }

        // if the player has been set in the inspector but the Tag is not set to "Player" log it
        if ((player != null) && (player.tag != "Player"))
        {
            Debug.LogWarning("EnemySpawn.Start(): The Player does not have its Tag set to 'Player'.");
        }

        // if the player has not been set in the inspector and can find by Tag set it
        if ((player == null) && (GameObject.FindGameObjectsWithTag("Player") != null))
        {
            Debug.LogWarning("EnemySpawn.Start(): Setting the missing player.");
            player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        }

        // Starts a coroutine function for spawning bouncing enemies and fly by enemy
        StartCoroutine(Spawner(SlimePrefab));
        StartCoroutine(Spawner(OrcPrefab));

        
    }

    void Awake()
    {
        // Create the list
        activeEnemies = new List<GameObject>();
    }

    IEnumerator Spawner(GameObject gobj)
    {
        //Wait 3 to 5 seconds when game starts to spawn a ball
        yield return new WaitForSeconds(Random.Range(1, 3));
        int i = Random.Range(spawnLimit - 3, spawnLimit);
        while(i < 5)
         {
            Vector3 spawnPoint = RandomPointWithinBorders();


            GameObject newEnemy = (GameObject)Instantiate(gobj, spawnPoint, Quaternion.identity);
            EnemyScript.enemiesLeft++;

            activeEnemies.Add(newEnemy);
            i++;
            yield return new WaitForSeconds(Random.Range(4, 6));
        }
    }

    

    public Vector3 RandomPointWithinBorders()
    {
        bool done = false;
        Vector3 randomPosition = new Vector3();

        while(!done)
         {
            //Code that will spawn a bouncing ball and ShowSpawn at a random position inside the borders 
            randomPosition.x = (int)UnityEngine.Random.Range(borderLeft.position.x, borderRight.position.x);
            randomPosition.y = (int)UnityEngine.Random.Range(borderBottom.position.y, borderTop.position.y);
            randomPosition.z = 0;

            done = ((minDistance == 0) || ValidMinimumDistance(randomPosition));
        }
        return randomPosition;
    }

    bool ValidMinimumDistance(Vector3 enemyPosition)
    {
        bool isValid = true;
        minDistance = Mathf.Abs(minDistance);

        if (player != null)
        {
            isValid = (Mathf.Abs(Vector3.Distance(player.position, enemyPosition)) > minDistance);
        }

        if (isValid && (activeEnemies.Count > 0))
        {
            for (int i = 0; i < activeEnemies.Count; i++)
            {
                if (Mathf.Abs(Vector3.Distance(activeEnemies[i].transform.position, enemyPosition)) < minDistance)
                {
                    isValid = false;
                    break;
                }
            }
        }
        return isValid;
    }
}