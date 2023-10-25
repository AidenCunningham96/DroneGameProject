using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    bool playerTouching;

    Rigidbody2D body;

    float ogMass;
    Boy_Controller boyCon;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boyCon = GameObject.FindWithTag("Boy").GetComponent<Boy_Controller>();
        ogMass = body.mass; 
    }

    // Update is called once per frame
    void Update()
    {
       
        if (boyCon.horizontal == 0 || !boyCon.isGrounded)
        {
            body.mass = ogMass;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Boy")
        {
            playerTouching = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Boy")
        {
            playerTouching = false;
        }
    }
}
