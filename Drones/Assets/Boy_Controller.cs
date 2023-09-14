using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Controller : MonoBehaviour
{
    public float moveX;

    public int moveSpeed;

    Rigidbody2D myRigidbody2D;

    void Start()
    {



    }


    void Update()
    {

        playerMove();


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
