using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MIScript : MonoBehaviour
{
    /* This script is for the Mental Inhibitor trap
    which reverses player movement controls for a duration
    of 10 seconds
    */

    public Rigidbody2D playerBody;
    float horizontal;
    float vertical;
//    public float timeRemaining = 10;
//    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    /*    horizontal = -Input.GetAxisRaw("Horizontal") * 10;
        vertical = -Input.GetAxisRaw("Vertical") * 10;

        playerBody.velocity = new Vector2(-horizontal, -vertical);

        */

    /*    if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        transform.localEulerAngles =new Vector3(0, 180, 0) ;

                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        transform.localEulerAngles = new Vector3(0, 0, 0);
                    }
                    playerBody.velocity = new Vector2(horizontal, vertical);
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    horizontal = Input.GetAxisRaw("Horizontal") * 7.5f;
                    vertical = Input.GetAxisRaw("Vertical") * 7.5f;
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        transform.localEulerAngles =new Vector3(0, 180, 0) ;

                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        transform.localEulerAngles = new Vector3(0, 0, 0);
                    }

                    playerBody.velocity = new Vector2(horizontal, vertical);
                    Debug.Log("Your Mind Suddenly Clears...");
                    timeRemaining = 0;
                    timerIsRunning = false;
                }

                Debug.Log(timeRemaining);
               
        }
        Debug.Log(timeRemaining);
//        transform.Translate(0, 0, Time.deltaTime * 1); */
    }

    

 /*   public void OnCollisionEnter2D(Collision2D other)
        {
        
            if (other.transform.tag == "Player")
            {
                
                 LevelManagerScript.KillPlayer();
                 Debug.Log("You have fallen into a pit!!!");

            }

        } */

        public void OnCollisionEnter2D(Collision2D other){

        if (other.transform.tag == "Player"){

            //timerIsRunning = true;
            Destroy(gameObject);



        }
    }
}
