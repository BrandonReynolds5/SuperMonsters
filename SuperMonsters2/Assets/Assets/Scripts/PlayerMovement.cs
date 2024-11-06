using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public  Rigidbody2D playerRigidBody;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isJumping;

    // public Animator playerAnim;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    public bool flippedLeft;
    public bool facingRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        //If statements for changing direction if going left or right
        // if(input < 0)
        // {
        //     spriteRenderer.flipX = true;
        // }
        // else if(input > 0)
        // {
        //     spriteRenderer.flipX = false;
        // }

        //Return true if circle around feet overlaps the ground, meaning player is grounded
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
        
        //Player jumps if on input and on the ground
        if(isGrounded == true && Input.GetButtonDown("Jump"))
        {   
            jumpTimeCounter = jumpTime;
            playerRigidBody.velocity = Vector2.up * jumpForce;
        }
        //Holds jump the longer you hold down jump button
        if(Input.GetButton("Jump") && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                playerRigidBody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            //If timer runs out or stop pushing jump, set isJumping to false
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }



    }

    //Will run at fixed 50 fps
    void FixedUpdate()
    {
        if(KBCounter <= 0)
        {
            playerRigidBody.velocity = new Vector2(input * speed, playerRigidBody.velocity.y);
        }
        else
        {
            if(KnockFromRight == true)
            {
                playerRigidBody.velocity = new Vector2(-KBForce, KBForce);
            }
            if(KnockFromRight == false)
            {
                playerRigidBody.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }

        if(input < 0)
        {
            facingRight = false;
            Flip(false);
            // spriteRenderer.flipX = true;
            // playerAnim.SetBool("isWalking", true);
        
        }
        else if(input > 0)
        {
            facingRight = true;
            Flip(true);
            // spriteRenderer.flipX = false;
            // playerAnim.SetBool("isWalking", true);
        }
        else if(input == 0)
        {
            // playerAnim.SetBool("isWalking", false);
        }
    }
    void Flip(bool facingRight)
    {
        if(flippedLeft && facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = false;
        }
        if(!flippedLeft && !facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = true;
        }
    }
}
