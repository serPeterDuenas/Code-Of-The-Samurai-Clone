using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement controls")]// Player's movement controls
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private int jumpPower = 15;
    [SerializeField] private float jumpResistance = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isFacingRight;
    private float moveX;
    private int moveDirection;
    private Rigidbody2D rb;
    // Player's logic for moving platform
    public bool isOnPlatform = false;
    public Rigidbody2D platformRB;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // checks if player is facing left, and if so will make the player face that direction
    // if not, then player's rotation is flipped
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        // This is to stop the player's velocity if they instantly switch directions, otherwise slide
        moveX = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = (int)Input.GetAxisRaw("Horizontal");

        // Checks the player's facing direction, and rotates their position accordingly
        if (moveDirection > 0 && isFacingRight)
        {
            Flip();
        }
        if (moveDirection < 0 && !isFacingRight)
        {
            Flip();
        }


        if (moveDirection != 0)
        {
            moveX = Mathf.MoveTowards(moveX, moveDirection * moveSpeed, Time.deltaTime * acceleration);
        }
        else
        // this stops player's movement as soon as player stops pressing the move buttons
        {
            moveX = 0;
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }


    }




    private bool isGrounded()
    {
        return Physics2D.OverlapCapsule
            (groundCheck.position, new Vector2(1f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }


    private void FixedUpdate()
    {
        // moves player's x-Axis with the calculation from Update
        //rb.velocity = new Vector3(moveX, rb.velocity.y, 0);


        // Adds resistance to vertical velocity. If the player is in middair or has not pressed jump,
        // then add force to y velocity
        if (rb.velocity.y < .075f * jumpPower || !Input.GetButtonDown("Jump"))
        {
            rb.velocity += Vector2.up * Physics.gravity.y * Time.fixedDeltaTime * jumpResistance;
        }


        // adds velocity to the player if the player is on a moving platform
        if (isOnPlatform)
        {
            rb.velocity = new Vector3(moveX + platformRB.velocity.x, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(moveX, rb.velocity.y, 0);
        }
    }
}
