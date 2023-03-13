using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChecker : MonoBehaviour
{
    public int levelCt;
    // Start is called before the first frame update
    void Start()
    {
        levelCt = 1;
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
        if (levelCt == 20 || PlayerScript.currHealth == 0 || PlayerScript.timeRemaining == 0)
        {
            SceneManager.LoadScene("Game Over");
        }

    }
}
