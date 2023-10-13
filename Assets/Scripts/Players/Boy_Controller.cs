using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boy_Controller : MonoBehaviour
{
    [HideInInspector]
    public float horizontal, vertical;

    public float walkSpeed = 8f;
    public float climbSpeed = 4f;

    public int jumpPower;
    public float fallMultiplier;

    public bool facingRight = true;
    //[HideInInspector]
    public bool Climbing, touchingBox, stillJumping, Climbable;

    bool flip;

    bool canMove = true;
    public GameObject droneObject;

    public Transform Feet;
    public float rayRadius;
    public LayerMask groundLayerMask;

    [HideInInspector]
    public bool isGrounded;

    [HideInInspector]
    public Rigidbody2D body;

    private Player_Controls controls;

    Vector2 vecGravity;

    [HideInInspector]
    public bool deadTrap, deadShot;

    void Awake()
    {
        controls = new Player_Controls();
    }

    void OnEnable()
    {
        controls.Boy.Enable();
    }
    void OnDisable()
    {
        controls.Boy.Disable();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }


    void Update()
    {
        if (!Climbing)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        if (controls.Boy.Jump.triggered && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }

        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        //if (controls.Boy.Interact.triggered && Climbable)
        //{
        //    Climbing = !Climbing;
        //}

        if (Climbable && canMove)
        {
            vertical = Input.GetAxisRaw("Vertical");

            body.velocity = new Vector2(0, vertical * climbSpeed);
            body.gravityScale = 0;
            
            if (!isGrounded)
            {
                Climbing = true;
                horizontal = 0;
            }
            else
            {
                Climbing = false;
            }
        }

        if (body.velocity.y < 0)
        {
            body.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
            stillJumping = false;
        }
        else
        {
            stillJumping = true;
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * walkSpeed, body.velocity.y);

        if (!Climbable)
        {
            body.gravityScale = 1;
        }

        RaycastHit2D hit = Physics2D.CircleCast(Feet.position, rayRadius, Vector2.down, 0, groundLayerMask);

        if (hit.collider != null)
        {
            isGrounded = true;
            stillJumping = false;
        }
        else
        {
            isGrounded = false;
        }
    }

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(Feet.position, rayRadius);
    //}

    public void Flip()
    {
        Vector3 currentScale = body.transform.localScale;
        currentScale.x *= -1;
        body.transform.localScale = currentScale;

        if (!flip)
        {
            flip = true;
            Invoke("ResetFlip", .05f);
        }
        facingRight = !facingRight;
    }
    void ResetFlip()
    {
        flip = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Climbable")
        {
            Climbable = true;
        }

        if (col.gameObject.tag == "Death_Trap")
        {
            deadTrap = true;
        }

        if (col.gameObject.tag == "Death_Shot")
        {
            deadShot = true;
        }

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            touchingBox = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            touchingBox = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Climbable")
        {
            Climbable = false;
            Climbing = false;
        }
    }

}
