using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : MonoBehaviour
{
    public float moveX;
    public float moveY;

    [Header("Speed Settings")]
    public float minSpeed = 1f;
    public float maxSpeed = 20f;
    float ogMaxSpeed;
    float moveSpeed;
    public int downwardDrift;

    float minSpeedOg;
    float maxSpeedOg;

    [Space(10)]
    [Header("Acceleration Settings")]
    public float acceleration = 2f;

    public float accelTime;

    public Transform Bottom;
    public float rayRadius;
    public LayerMask groundLayerMask;

    [HideInInspector]
    public bool isGrounded;

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
        //controls.Drone.Fly_Up.performed += ctx => Flying();
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

        minSpeedOg = minSpeed;
        maxSpeedOg = maxSpeed;

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
        moveY = Input.GetAxis("Vertical");

        RaycastHit2D hit = Physics2D.CircleCast(Bottom.position, rayRadius, Vector2.down, 0, groundLayerMask);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //if (flying)
        //{
        //    moveY = 1;
        //}
        //else
        //{
        //    moveY = 0;
        //}
        

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

        if (!isStill)
        {
            accelTime += acceleration * Time.deltaTime;
            moveSpeed = Mathf.Lerp(minSpeed, maxSpeed, accelTime);

            body.velocity = new Vector2(moveX, moveY) * (moveSpeed * 100) * Time.deltaTime;
        }
        else
        {
            accelTime = 0;
        }
        
        

        //accel fail safe. 
        if (acceleration < 1)
        {
            acceleration = 1;
        }

    }

    //void Flying()
    //{
    //    flying = !flying;
    //}
}
