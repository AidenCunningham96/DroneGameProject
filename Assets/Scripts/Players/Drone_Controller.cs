using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : MonoBehaviour
{

    public float droneFlyForce;
    
    public float moveX;

    public int moveSpeed;

    private float roll = 0f;
    private float pitch = 0f;

    Rigidbody2D body;
    //Animator anim;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    void OnDisable()
    {
        body.bodyType = RigidbodyType2D.Kinematic;
        body.velocity = Vector3.zero;
    }

    void Update()
    {

        playerMove();

        if (moveX > 0.0f)
        {
            roll = -35;
        }
        else if (moveX < 0.0f)
        {
            roll = 35;
        }

        if (moveX == 0)
        {
            roll = 0;
        }


        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(pitch, 0f, roll), 120.0f * Time.deltaTime);

    }

    void FixedUpdate()
    {
        bool droneFlyActive = Input.GetButton("Fire1");

        if (droneFlyActive)
        {
            body.AddForce(new Vector2(0, droneFlyForce));
            //anim.SetBool("isFlying", true);
        }
        else
        {
           // anim.SetBool("isFlying", false);
            roll = 0;
        }
    }

    void playerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        
        body.velocity = new Vector2(moveX * moveSpeed, body.velocity.y);

        if (moveX != 0)
        {
            
        }
        else
        {
            
        }
    }
}
