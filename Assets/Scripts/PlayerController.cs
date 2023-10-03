using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float droneFlyForce;
    
    public float moveX;

    public int moveSpeed;

    private float roll = 0f;
    private float pitch = 0f;

    Rigidbody2D myRigidbody2D;


	
	void Start ()
    {

        

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
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, droneFlyForce));
            GetComponent<Animator>().SetBool("isFlying", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isFlying", false);
            roll = 0;
        }
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
