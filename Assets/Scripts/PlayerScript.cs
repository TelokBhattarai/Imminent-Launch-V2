using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static float speed;
    public static int lives;
    public static int coins_collected;
    public static float timeRemaining = 10;
    public static bool timerIsRunning = false;

    private void Start()
    {
        lives = 3;
        speed = 7.5f;
        coins_collected = 0;
    }

    private void FixedUpdate()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;
            }
            else
            {

                changeSpeed(7.5f);
                Debug.Log("Your Body Begins To Slow...");
                timeRemaining = 0;
                timerIsRunning = false;
            }


        }
    }

    // Helper functions for powerups
    // Makes code a bit more readable

    public static void addLife()
    {
        lives += 1;
    }

    public static void removeLife()
    {
        lives -= 1;
    }

    public static void addCoin(int amount)
    {
        coins_collected += amount;
    }

    public static void changeSpeed(float speedval)
    {
        speed = speedval;
    }
    // public static void reverseControls(float )

    // assists with MI trap/Script and MUP powerup
    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.tag == "MI")
        {
            Movement.startTimer();
        }

        if (other.transform.tag == "MUP")
        {
            timerIsRunning = true;
            changeSpeed(15);
            Debug.Log("Energy Suddenly Surges Within Your Body!!!");
        }
    }

}
