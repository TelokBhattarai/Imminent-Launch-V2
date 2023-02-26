using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject target;
    public int health = 100;
    public int max_vel = 10;
    public int max_speed = 10;
    public int slowing_rad = 4;
    public bool seeking = true;

    private void seek()
    {
        Vector2 desired_vel = ((Vector2)target.transform.position - (Vector2)gameObject.transform.position);
        desired_vel.Normalize();

        float distance = Vector2.Distance(gameObject.transform.position, target.transform.position);

        Debug.Log(distance);

        if (distance < slowing_rad)
        {
            desired_vel = desired_vel.normalized * max_vel * (distance / slowing_rad);
        }
        else
        {
            desired_vel = desired_vel.normalized * max_vel;
        }

        Vector2 steer = desired_vel - rb.velocity;

        steer.x = Mathf.Clamp(steer.x, float.MinValue, max_speed);
        steer.y = Mathf.Clamp(steer.y, float.MinValue, max_speed);

        steer /= rb.mass;

        Vector2 vel = desired_vel + steer;

        print(vel);

        rb.velocity += vel;
    }

    public void takeDamage(int n)
    {
        health -= n;
    }

    private void Update()
    {
        if (target != null)
            seek();
        else
            rb.velocity = Vector2.zero;

        if(health <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            target = collision.gameObject;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            target = null;
    }
}
