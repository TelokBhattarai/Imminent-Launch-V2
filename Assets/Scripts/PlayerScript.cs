using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static float timeRemaining = 20;
    public static float speed = 7;
    public static int coins = 0;
    public static int keys = 0;
    public static int maxHealth = 100;
    public static int currHealth = 100;
    public static bool hasPowerArmor = false;


    public int damagePlayer(int n)
    {
        if (currHealth - n <= 0)
        {
            Debug.Log("Dead");
            return 0;
        }
        else
        {
            currHealth -= n;
            return currHealth;
        }
    }
    
    public int healPlayer(int n)
    {
        currHealth = (currHealth + n)  > maxHealth ? maxHealth : currHealth + n;
        return currHealth;
    }

    private void Update()
    {
        if (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time is out!");
        }
    }
}
