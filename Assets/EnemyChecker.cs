using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChecker : MonoBehaviour
{
    public int levelCt = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Enemy") == null & levelCt < 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if (levelCt % 5 == 0)
            {
                EnemySpawn.spawnLimit += 2;
            }
        }
        if (levelCt == 20)
        {
            // SceneManager.LoadScene(*insertendscene*);
        }

    }
}
