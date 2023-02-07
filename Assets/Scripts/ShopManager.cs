using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject Panel;

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
        WeaponManager.upgrade("longbow");
    }

    public void UpgradeCrossBow()
    {
        WeaponManager.upgrade("crossbow");
    }

    public void UpgradeSword()
    {
        WeaponManager.upgrade("sword");
    }

    public void UpgradeArmor()
    {
        WeaponManager.upgrade("armor");
    }

    public void Update()
    {
        longBow.text = "Level: " + WeaponManager.LongBowLevel;
        sword.text = "Level: " + WeaponManager.SwordLevel;
        crossBow.text = "Level: " + WeaponManager.CrossBowLevel;
        armor.text = "Level: " + WeaponManager.ArmorLevel;

    }

}
