using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Controller : MonoBehaviour
{
    public float horizontal;
    public float vertical;

    public float walkSpeed = 8f;
    public float climbSpeed = 4f;

    public bool facingRight = true;
    //[HideInInspector]
    public bool Climbing;
    bool Climbable;
    bool flip;

    bool canMove = true;
    public GameObject droneObject;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.E) && Climbable)
        {
            Climbing = !Climbing;
        }

        if (Climbing && canMove)
        {
            vertical = Input.GetAxisRaw("Vertical");
            if (vertical == 0)
            {
                //anim.Play("MC_Climb_Idle");
            }
            else
            {
                //anim.Play("MC_Climb");
            }

            body.velocity = new Vector2(0, vertical * climbSpeed);
            body.gravityScale = 0;
            //isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * walkSpeed, body.velocity.y);

        if (!Climbing)
        {
            body.gravityScale = 1;
        }
    }

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
