using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int walkSpeed = 10;
    public int jumpSpeed = 8;
    float direction = 0f;

    Rigidbody2D playerBody;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public static bool isTouchingGround;

    public static Vector3 playerPosition;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        playerPosition = transform.position;

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x * Time.deltaTime, jumpSpeed);
        }


    }

    void FixedUpdate()
    {
        if (direction > 0f)
        {
            playerBody.velocity = new Vector2(direction * walkSpeed * Time.deltaTime, playerBody.velocity.y);
        }
        else if (direction < 0f)
        {
            playerBody.velocity = new Vector2(direction * walkSpeed * Time.deltaTime, playerBody.velocity.y);
        }
        else 
        {
            playerBody.velocity = new Vector2(0, playerBody.velocity.y);
        }
    }
}
