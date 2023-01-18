using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    public Rigidbody2D playerBody;

    float horizontal;
    float vertical;
    public float timeRemaining = 10;
    public static bool timerIsRunning = false;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log(horizontal);
        Debug.Log(vertical);


        if (!timerIsRunning)
        {
            horizontal = Input.GetAxisRaw("Horizontal") * PlayerScript.speed;
            vertical = Input.GetAxisRaw("Vertical") * PlayerScript.speed;


            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }

            playerBody.velocity = new Vector2(horizontal, vertical);
        }

        // code segement designed to work with the Mental Inhibitor trap

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                horizontal = -Input.GetAxisRaw("Horizontal") * PlayerScript.speed;
                vertical = -Input.GetAxisRaw("Vertical") * PlayerScript.speed;
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);

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
                horizontal = Input.GetAxisRaw("Horizontal") * PlayerScript.speed;
                vertical = Input.GetAxisRaw("Vertical") * PlayerScript.speed;
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);

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


        }
    }
    public static void startTimer()
    {

        Debug.Log("Your Mind Has Been Scrambled!!!");
        timerIsRunning = true;
        Debug.Log(timerIsRunning);
    }
}
