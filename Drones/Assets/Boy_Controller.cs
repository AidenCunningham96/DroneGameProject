using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Controller : MonoBehaviour
{
    public float moveX;

    public int moveSpeed;

    Rigidbody2D myRigidbody2D;

    public GameObject camera;

    public GameObject droneObject;

    public Camera_Follow cameraScript;

    void Start()
    {

        cameraScript = camera.GetComponent<Camera_Follow>();

    }


    void Update()
    {

        playerMove();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            cameraScript.droneIsDeployed = true;
            Instantiate(droneObject);
        }
    }

    void FixedUpdate()
    {
       
    }

    void playerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (moveX != 0)
        {

        }
        else
        {

        }
    }

}
