using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockScript : MonoBehaviour
{
    public GameObject door;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(door);
        Destroy(gameObject);
    }
}
