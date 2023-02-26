using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaArmor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (PlayerScript.hasPowerArmor)
        {
            Destroy(gameObject);
        }

        PlayerScript.currHealth = 150;
        PlayerScript.hasPowerArmor = true;

        Destroy(gameObject);


    }
}
