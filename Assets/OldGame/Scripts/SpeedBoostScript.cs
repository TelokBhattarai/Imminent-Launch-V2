using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
    // Start is called before the first frame update
    // self-explainatory script

    

    private void FixedUpdate()
    {/*

        if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                   
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                   
                    PlayerScript.changeSpeed(7.5f);
                    Debug.Log("Your Body Begins To Slow...");
                    timeRemaining = 0;
                    timerIsRunning = false;
                }

               
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player"){

            
            Destroy(gameObject);

        }
        
    }
}
