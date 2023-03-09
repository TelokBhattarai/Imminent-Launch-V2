using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
