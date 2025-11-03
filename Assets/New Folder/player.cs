using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 3f ;
    public float sprintMultiplier = 3f;
    public float jumpForce = 10f ;
    public int maxJumps = 2;
    

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public GroundChecker groundChecker;

    public float moveInput ;
    private bool isJump ;
    private int jumpCount;
    private bool isSprinting;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
    

        isSprinting = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }


        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }


        if (groundChecker.isGrounded)
        {
            jumpCount = 0;
        }

        if (moveInput!=0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }


        if (isSprinting)
        {
            animator.SetBool("isSprint", true);
        }
        else
        {
            animator.SetBool("isSprint", false);
        }


    }

    private void FixedUpdate()
    {
        float currentSpeed = moveSpeed;
        if (isSprinting)
            currentSpeed *= sprintMultiplier;

        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);

        if (isJump)
        {
            if (groundChecker != null && groundChecker.isGrounded || jumpCount < maxJumps)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount++;
            }
            isJump = false;
        }
    }
    
    
}
