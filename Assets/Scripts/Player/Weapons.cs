using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject shootPoint;
    public GameObject longBowArrow;
    public GameObject shortBowArrow;
    public GameObject slashRadius;

    private Vector2[] directionVectors = { Vector2.left, Vector2.right, Vector2.up, Vector2.down };

    private bool Slashing = false;
    public float slashTimer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 start = shootPoint.transform.position;

        Debug.DrawRay(start, directionVectors[((int)Movement.dir)]*10, Color.red);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            shoot(longBowArrow, start);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            shoot(shortBowArrow, start);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            slash();
        }

        if (Slashing)
        {
            if(slashTimer - Time.deltaTime < 0)
            {
                Slashing = false;
                slashRadius.GetComponent<SpriteRenderer>().enabled = false;
                slashTimer = 0.5f;
            }
            else
            {
                slashTimer -= Time.deltaTime;
            }
        }
    }

    void shoot(GameObject proj, Vector3 pos)
    {
        GameObject arr = Instantiate(proj);

        arr.transform.position = pos;

        arr.GetComponent<Rigidbody2D>().AddForce(directionVectors[(int)Movement.dir] * 300f);
    }

    void slash()
    {
        slashRadius.GetComponent<SpriteRenderer>().enabled = true;

        Slashing = true;

    }

}
