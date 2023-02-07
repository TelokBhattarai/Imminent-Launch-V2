using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float time;

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
        Destroy(gameObject);
    }
}
