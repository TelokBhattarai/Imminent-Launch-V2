using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float time;

    public string type;

    public int damage;

    // Update is called once per frame
    void Update()
    {
        if(time - Time.deltaTime > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);

        if (!collision.gameObject.CompareTag("Enemy"))
            return;

        EnemyScript enemy = collision.gameObject.GetComponentInChildren<EnemyScript>();


        if(type == "long")
        {
            enemy.takeDamage(damage * WeaponManager.LongBowLevel);
        }
        else
            enemy.takeDamage(damage * WeaponManager.CrossBowLevel);

        Debug.Log(enemy.health);

        Destroy(gameObject);
    }
}
