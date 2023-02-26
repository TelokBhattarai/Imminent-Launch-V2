using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static int SwordLevel = 1;
    public static int ArmorLevel = 1;
    public static int CrossBowLevel = 1;
    public static int LongBowLevel = 1;

    public static int[] swordUpgradeCost = { 10, 20, 30 };
    public static int[] longBowUpgradeTree = { 10, 20, 30 };
    public static int[] crossBowUpgradeTree = { 10, 20, 30 };
    public static int[] armorUpgradeTree = { 10, 20, 30 };

    public static void upgrade(string item, bool free = false)
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
                upgradable(ref ArmorLevel, armorUpgradeTree, free);
                break;

        }
    }

    private static void upgradable(ref int level, int[] costTree, bool free)
    {
        if (free)
        {
            level++;
            return;
        }


        if (PlayerScript.coins >= costTree[level-1] && level-1 < swordUpgradeCost.Length)
        {
            PlayerScript.useCoins(costTree[level]);
            level++;
            return;
        }

    }

}
