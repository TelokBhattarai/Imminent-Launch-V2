using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeaponUpgrade : MonoBehaviour
{
    private string[] weapons = { "longbow", "crossbow", "sword", "armor" };

    public WeaponManager WeaponManager;

    void Start()
    {
        WeaponManager = GameObject.FindWithTag("HUD").GetComponent<WeaponManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WeaponManager.upgrade(weapons[Random.Range(0, weapons.Length)], true);
            Destroy(gameObject);
        }
    }


}
