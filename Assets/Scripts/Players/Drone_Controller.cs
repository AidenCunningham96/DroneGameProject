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

    [HideInInspector]
    public bool flying;

    private Player_Controls controls;

    public Grabber grabberScript;

    void Awake()
    {
        controls = new Player_Controls();
        controls.Drone.Fly.performed += ctx => Flying();
    }

    void OnEnable()
    {
        controls.Drone.Enable();
    }
    void OnDisable()
    {
        controls.Drone.Disable();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector3.zero;
        grabberScript = GameObject.Find("Grab_Point").GetComponent<Grabber>();

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

        if (controls.Drone.Grab.triggered)
        {
            grabberScript.TryGrab();
        }
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");

        if (flying)
        {
            moveY = 1;
        }
        else
        {
            moveY = 0;
        }
        

        if (moveX > .5f)
        {
            roll = -rollAmount;
        }
        if (moveX < -.5f)
        {
            roll = rollAmount;
        }

        if (moveX == 0 && !flying)
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

    void Flying()
    {
        flying = !flying;
    }
}
