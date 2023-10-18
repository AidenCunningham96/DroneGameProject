using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Animator : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;

    Boy_Controller boyCon;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Kid_Animator").GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        boyCon = GetComponent<Boy_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boyCon.deadTrap && !boyCon.deadShot)
        {
            if (boyCon.isGrounded && boyCon.enabled && !boyCon.Climbing)
            {
                anim.SetBool("Fall", false);
                anim.SetBool("Jump", false);
                if (boyCon.horizontal == 0 && boyCon.vertical == 0)
                {
                    anim.SetBool("Walk", false);

                    anim.SetBool("Pushing", false);
                }

                if (boyCon.horizontal != 0)
                {
                    if (!boyCon.touchingBox)
                    {
                        anim.SetBool("Walk", true);
                    }
                    else
                    {
                        if (boyCon.horizontal != 0)
                        {
                            anim.SetBool("Pushing", true);
                        }
                        else
                        {
                            anim.SetBool("Pushing", false);
                        }
                    }                  
                }
            }
            if (!boyCon.isGrounded && boyCon.enabled && !boyCon.Climbing)
            {
                if (!boyCon.stillJumping)
                {
                    anim.SetBool("Fall", true);
                    anim.SetBool("Jump", false);
                }
                else
                {
                    anim.SetBool("Fall", false);
                    anim.SetBool("Jump", true);
                }
            }

            if (!boyCon.enabled)
            {
                anim.SetBool("Drone", true);
                body.velocity = Vector3.zero;
            }
            else
            {
                anim.SetBool("Drone", false);
            }
        }
        
        if (boyCon.Climbing)
        {
            if (boyCon.vertical == 0)
            {
                anim.Play("Kid_Ladder_Idle");
            }
            else
            {
                anim.SetBool("Climbing", true);
            }
        }
        if (!boyCon.Climbing)
        {
            anim.SetBool("Climbing", false);
        }

        if (boyCon.deadTrap)
        {
            anim.SetBool("Death_Trap", true);
        }

        if (!boyCon.touchingBox)
        {
            anim.SetBool("Pushing", false);
        }
       
    }
}
