using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float joystickSensitivity = 0.2f;
    public float horizontalForce;
    public float jumpForce;
    public float maxSpeedX;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb2d);
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        if (joystick.Horizontal > joystickSensitivity)
        {
            //Right
            rb2d.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            Debug.Log("Move Right");
        }

        if (joystick.Horizontal < -joystickSensitivity)
        {
            //Left
            rb2d.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            Debug.Log("Move Left");
        }

    }
}
