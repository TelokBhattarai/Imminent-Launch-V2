using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI megaArmor;
    public TextMeshProUGUI key;
    public TextMeshProUGUI timer;


    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + PlayerScript.currHealth.ToString();
        coins.text = "Coins: " + PlayerScript.coins.ToString();
        key.text = "Keys: " + PlayerScript.keys.ToString();
        timer.text = "Timer: " +PlayerScript.timeRemaining.ToString();
        megaArmor.text = "Mega Armor: " + PlayerScript.hasPowerArmor.ToString();
    }
}
