using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void start_game()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void return_to_start()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
