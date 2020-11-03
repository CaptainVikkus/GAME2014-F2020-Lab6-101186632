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

    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb2d);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer);
        animator = GetComponent<Animator>();
        Assert.IsNotNull(animator);
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        //Only move if touching ground
        if (isGrounded)
        {
            if (joystick.Horizontal > joystickSensitivity)
            {
                //Right
                rb2d.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = false;
                animator.SetInteger("AnimState", 1);
                Debug.Log("Move Right");
            }
            else if (joystick.Horizontal < -joystickSensitivity)
            {
                //Left
                rb2d.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
                spriteRenderer.flipX = true;
                animator.SetInteger("AnimState", 1);
                Debug.Log("Move Left");
            }
            else if (joystick.Vertical > joystickSensitivity)
            {
                //Jump
                rb2d.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            }
            else
            {
                animator.SetInteger("AnimState", 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
