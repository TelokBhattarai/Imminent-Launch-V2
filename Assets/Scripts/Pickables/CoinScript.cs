using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int amount;
    public static AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerScript.coins += amount;
            source.Play();
            Destroy(gameObject);
        }
    }
}
