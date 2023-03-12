using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private GameObject playerObject = null;

    public int damage = 10;

    private float t = 1;
    private float ct = 0;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerObject = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerObject = null;
        }
    }


    private void Update()
    {
        if(playerObject != null)
        {
            ct += Time.deltaTime;

            if(ct >= t)
            {
                ct = 0;
                playerObject.GetComponent<PlayerScript>().damagePlayer(damage);
            }
        }
        else
        {
            ct = 0;
        }
    }
}
