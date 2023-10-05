using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : MonoBehaviour
{
    float moveX;
    float moveY;

    public int moveSpeed;
    public int downwardDrift;

    public float rollSpeed = 1f;

    private float roll = 0f;
    public float rollAmount = 35f;
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

        if (moveX > .5f)
        {
            roll = -rollAmount;
        }
        if (moveX < -.5f)
        {
            roll = rollAmount;
        }

        if (moveX == 0 && moveY == 0)
        {
            isStill = true;
        }
        else
        {
            isStill = false;
        }

        if ((moveX < 0f && moveX > -.5f) || (moveX < .5f && moveX > 0f))
        {
            roll = 0;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(pitch, 0f, roll), rollSpeed * 100 * Time.deltaTime);

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
