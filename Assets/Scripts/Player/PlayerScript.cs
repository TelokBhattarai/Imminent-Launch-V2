using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static float timeRemaining = 3000;
    public static float speed = 7;
    public static int coins = 1000;
    public static int keys = 0;
    public static int maxHealth = 100;
    public static int currHealth = 100;
    public static bool hasPowerArmor = false;

    public HealthBar bar;

    private void Awake()
    {
        timeRemaining = 40;
        speed = 7;
        coins = 10;
        maxHealth = 100;
        currHealth = 100;
    }

    private void Start()
    {
        bar.SetMaxHealth(maxHealth);
    }

    public int damagePlayer(int n)
    {
        bar.setHealth(currHealth - n);

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

    public static int useCoins(int n)
    {
        if (coins - n >= 0)
            coins -= n;

        return coins;
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


        if (hasPowerArmor && currHealth <= 100)
            hasPowerArmor = false;
    }
}
