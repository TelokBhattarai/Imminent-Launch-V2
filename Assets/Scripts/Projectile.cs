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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);

        if (!other.gameObject.CompareTag("Enemy"))
            return;

        EnemyScript enemy = other.gameObject.GetComponentInChildren<EnemyScript>();


        if (type == "long")
        {
            enemy.takeDamage(damage * WeaponManager.LongBowLevel);
        }
        else
            enemy.takeDamage(damage * WeaponManager.CrossBowLevel);

        Debug.Log(enemy.health);

        Destroy(gameObject);
    }

   
}
