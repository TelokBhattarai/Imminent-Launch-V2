using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaArmour : MonoBehaviour
{

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public bool isActive = false;
    public GameObject Player;
/* Script designed for the MegaArmour powerup, which protects
the player from all soures of damage for 5 seconds
*/
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
         if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                //    playerR = GameObject.FindGameObjectsWithTag("Player")
                //    Player.GetComponent<BoxCollider2D>().SetActive(false);
                //    Player.GetComponent<Rigidbody2D>().enabled = false;
                    timeRemaining -= Time.deltaTime;
                }
                else{
            
                    Debug.Log(LevelManagerScript.MA);
                    LevelManagerScript.updateArmour();
                    Debug.Log(LevelManagerScript.MA);
                //    Player.GetComponent<Rigidbody2D>().enabled = true;
                    timeRemaining = 0;
                    timerIsRunning = false;
                    Debug.Log("You feel weakness creep back into your body...");
                }

                Debug.Log(timeRemaining);
               
        }
        Debug.Log(timeRemaining);

        */
    }

    public void OnCollisionEnter2D(Collision2D other){

        if (other.transform.tag == "Player"){

            
            Destroy(gameObject);
            

        }


    }

}
