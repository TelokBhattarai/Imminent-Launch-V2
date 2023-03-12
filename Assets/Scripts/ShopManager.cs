using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject Panel;

    public WeaponManager weaponManager;


    // Weapon levels
    public TextMeshProUGUI crossBow;
    public TextMeshProUGUI sword;
    public TextMeshProUGUI longBow;
    public TextMeshProUGUI armor;



    // Start is called before the first frame update
    public void ClosePanel()
    {
        Panel.SetActive(false);
    }

    public void UpgradeLongBow()
    {
        weaponManager.upgrade("longbow");
    }

    public void UpgradeCrossBow()
    {
        weaponManager.upgrade("crossbow");
    }

    public void UpgradeSword()
    {
        weaponManager.upgrade("sword");
    }

    public void UpgradeArmor()
    {
        weaponManager.upgrade("armor");
    }

    public void Update()
    {
        longBow.text = "Level: " + WeaponManager.LongBowLevel;
        sword.text = "Level: " + WeaponManager.SwordLevel;
        crossBow.text = "Level: " + WeaponManager.CrossBowLevel;
        armor.text = "Level: " + WeaponManager.ArmorLevel;

    }

}
