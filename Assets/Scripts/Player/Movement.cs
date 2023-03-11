using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    public static Directions dir = Directions.LEFT;

    public Transform shoot;

    public Rigidbody2D playerBody;

    float horizontal;
    float vertical;

    // Actual movement code. This applies force to the rigidbody to move it around;

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * PlayerScript.speed;
        vertical = Input.GetAxisRaw("Vertical") * PlayerScript.speed;

        playerBody.velocity = new Vector2(horizontal, vertical);
    }


    // This just changes the rotation to match the direction the player wants to move;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            changeDirection(0, Directions.TOP);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            changeDirection(90, Directions.LEFT);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            changeDirection(180, Directions.BOTTOM);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            changeDirection(270, Directions.RIGHT);
        }
    }


    private void changeDirection(int angle, Directions direction)
    {
        shoot.localEulerAngles = new Vector3(0, 0, angle);
        dir = direction;
    }
}
