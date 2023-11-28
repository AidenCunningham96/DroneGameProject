using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Animator : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;

    public bool jump;
    public bool jumping;
    bool relinquish;

    public float timeBeforeFall = .1f;

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
                if (!jumping)
                {
                    anim.SetBool("Jump", false);
                    anim.SetBool("Landing", true);
                    jump = false;
                }
                

                if (boyCon.horizontal == 0 && boyCon.vertical == 0)
                {
                    anim.SetBool("Walk", false);
                }

                if (boyCon.horizontal != 0)
                {
                    if (!boyCon.touchingBox)
                    {
                        anim.SetBool("Walk", true);
                        anim.SetBool("Push", false);
                    }
                    else
                    {
                        anim.SetBool("Push", true);
                        anim.SetBool("Walk", false);
                    }                  
                }
                else
                {
                    anim.SetBool("Push", false);
                }
            }

            if (!boyCon.Climbing && !boyCon.isGrounded)
            {
                anim.SetBool("Walk", false);

                anim.Play("Kid_Jump_Idle");
            }

            if (boyCon.controls.Boy.Jump.triggered && boyCon.enabled && !boyCon.Climbing)
            {
                anim.SetBool("Jump", true);

                if (!jump)
                {
                    jumping = true;
                    jump = true;                   
                    Invoke("SetLanding", .5f);
                }
                
            }

            if (!boyCon.enabled)
            {
                if (!relinquish)
                {
                    relinquish = true;
                    SetAllFalse();
                    anim.SetTrigger("Control_Drone");
                    body.velocity = Vector3.zero;
                }
                
            }
            else
            {
                if (relinquish)
                {
                    relinquish = false;
                    anim.SetTrigger("Control_Drone");
                }
            }
        }
        
        if (boyCon.Climbing)
        {
            anim.SetBool("Climbing", true);

            if (boyCon.vertical == 0)
            {
                anim.SetInteger("Climb_State", 0);
            }
            else
            {
                anim.SetInteger("Climb_State", 1);
            }
        }
        else
        {
            anim.SetBool("Climbing", false);
        }

        if (boyCon.deadTrap)
        {
            anim.Play("Kid_Death_Trap");
        }

        if (!boyCon.touchingBox)
        {
        }
       
    }

    void SetAllFalse()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Landing", false);
    }

    void SetLanding()
    {
        anim.SetBool("Landing", false);
        jumping = false;
    }
}
