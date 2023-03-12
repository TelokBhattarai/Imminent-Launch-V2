using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static int SwordLevel = 1;
    public static int ArmorLevel = 1;
    public static int CrossBowLevel = 1;
    public static int LongBowLevel = 1;

    public int[] swordUpgradeCost = { 10, 20, 30 };
    public int[] longBowUpgradeTree = { 10, 20, 30 };
    public int[] crossBowUpgradeTree = { 10, 20, 30 };
    public int[] armorUpgradeTree = { 10, 20, 30 };

    public PlayerScript player;


    public void upgrade(string item, bool free = false)
    {
        switch (item)
        {
            case "sword":
                upgradable(ref SwordLevel, swordUpgradeCost, free);
                break;
            case "longbow":
                upgradable(ref LongBowLevel, longBowUpgradeTree, free);
                break;
            case "crossbow":
                upgradable(ref CrossBowLevel, crossBowUpgradeTree, free);
                break;
            case "armor":
                bool upgraded = upgradable(ref ArmorLevel, armorUpgradeTree, free);
                if (upgraded)
                {
                    PlayerScript.maxHealth = (100 * ArmorLevel);
                    PlayerScript.currHealth = PlayerScript.maxHealth;
                    player.bar.setHealth(PlayerScript.currHealth);
                }
                break;

        }
    }

    private bool upgradable(ref int level, int[] costTree, bool free)
    {
        if (free)
        {
            level++;
            return true;
        }


        if (PlayerScript.coins >= costTree[level-1] && level-1 < swordUpgradeCost.Length)
        {
            PlayerScript.useCoins(costTree[level]);
            level++;
            return true;
        }

        return false;

    }

}
