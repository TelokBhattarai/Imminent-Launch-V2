using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    // Player stuff
    public TextMeshProUGUI health;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI megaArmor;
    public TextMeshProUGUI key;
    public TextMeshProUGUI timer;

    // Weapon levels
    public TextMeshProUGUI crossBow;
    public TextMeshProUGUI sword;
    public TextMeshProUGUI longBow;



    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + PlayerScript.currHealth.ToString();
        coins.text = "Coins: " + PlayerScript.coins.ToString();
        key.text = "Keys: " + PlayerScript.keys.ToString();
        timer.text = "Timer: " +PlayerScript.timeRemaining.ToString("0");
        megaArmor.text = "Mega Armor: " + PlayerScript.hasPowerArmor.ToString();
        longBow.text = "LongBow: " + WeaponManager.LongBowLevel;
        sword.text = "Sword: " + WeaponManager.SwordLevel;
        crossBow.text = "LongBow: " + WeaponManager.CrossBowLevel;

    }
}
