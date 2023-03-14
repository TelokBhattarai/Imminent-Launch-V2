using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    // Player stuff
    public TextMeshProUGUI health;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI megaArmor;
    public TextMeshProUGUI key;
    public TextMeshProUGUI timer;
    public Text enemies;

    // Weapon levels
    public TextMeshProUGUI crossBow;
    public TextMeshProUGUI sword;
    public TextMeshProUGUI longBow;

    public WeaponManager weaponManager;



    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + PlayerScript.currHealth.ToString();
        coins.text = " " + PlayerScript.coins.ToString();
        key.text = " " + PlayerScript.keys.ToString();
        timer.text = " " +PlayerScript.timeRemaining.ToString("0");
        longBow.text = "LongBow: " + WeaponManager.LongBowLevel;
        sword.text = "Sword: " + WeaponManager.SwordLevel;
        crossBow.text = "Crossbow: " + WeaponManager.CrossBowLevel;
        enemies.text = "Enemies Left: " + EnemyScript.enemiesLeft;

    }
}
