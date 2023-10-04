using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Controller : MonoBehaviour
{
    public float horizontalMove;

    public float walkSpeed = 8f;

    public bool isFacingRight = true;

    Rigidbody2D myRigidbody2D;

    public GameObject droneObject;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        
    }


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            Destroy(collision.gameObject);

        }
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * walkSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontalMove < 0f || !isFacingRight && horizontalMove > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= 1f;
            transform.localScale = localScale;
        }
    }

}
