using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : MonoBehaviour
{

    public float droneFlyForce;
    
    float moveX;
    float moveY;

    public int moveSpeed;
    public int downwardDrift;

    public float rollSpeed = 100f;

    private float roll = 0f;
    private float pitch = 0f;

    Rigidbody2D body;
    //Animator anim;

    bool isActive;
    public bool isStill;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector3.zero;

        //anim = GetComponent<Animator>();
    }

    //void OnDisable()
    //{
    //    body.simulated = false;
    //    isActive = false;
    //    body.velocity = Vector3.zero;
    //    roll = 0;
    //    transform.rotation = Quaternion.identity;
    //}

    void Update()
    {
        //if (this.enabled && !isActive)
        //{
        //    isActive = true;
        //    body.simulated = true;
        //}
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (moveX > 0.0f)
        {
            roll = -35;
        }
        else if (moveX < 0.0f)
        {
            roll = 35;
        }

        if (moveX == 0 && moveY == 0)
        {
            roll = 0;
            isStill = true;
        }
        else
        {
            isStill = false;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(pitch, 0f, roll), rollSpeed * Time.deltaTime);

        if (isStill)
        {
            body.velocity = new Vector2(moveX, -downwardDrift) * (moveSpeed * 10) * Time.deltaTime;
        }
        else
        {
            body.velocity = new Vector2(moveX, moveY) * (moveSpeed * 100) * Time.deltaTime;
        }
        
    }
}
