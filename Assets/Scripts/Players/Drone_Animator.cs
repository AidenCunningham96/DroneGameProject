using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Animator : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;

    Drone_Controller droneCon;
    Grabber grabberScript;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Drone_Animator").GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        droneCon = GetComponent<Drone_Controller>();
        grabberScript = GameObject.Find("Grab_Point").GetComponent<Grabber>();
    }

    // Update is called once per frame
    void Update()
    {
        if (droneCon.enabled && !droneCon.isGrounded)
        {
            anim.SetBool("Grounded", false);

            anim.SetBool("Flight", true);

            if (grabberScript.Grabbed || grabberScript.tryingGrab)
            {
                anim.SetBool("Grab", true);
            }
            
            if (!grabberScript.Grabbed && !grabberScript.tryingGrab)
            {
                anim.SetBool("Grab", false);
            }
        }
        else
        {
            anim.SetBool("Flight", false);
        }

        if (!droneCon.enabled)
        {
            anim.SetBool("Grounded", true);
        }

        if (droneCon.isGrounded)
        {
            anim.SetBool("Grounded", true);
        }
       
    }
}
