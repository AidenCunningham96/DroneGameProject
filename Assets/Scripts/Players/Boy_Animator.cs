using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Animator : MonoBehaviour
{
    Animator anim;

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
                if (boyCon.horizontal == 0 && boyCon.vertical == 0)
                {
                    anim.SetBool("Walk", false);
                }

                if (boyCon.horizontal != 0)
                {
                    anim.SetBool("Walk", true);
                }
            }
            if (!boyCon.isGrounded && boyCon.enabled)
            {
                anim.SetBool("Fall", true);
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
            anim.Play("LadderClimb");
        }

        if (boyCon.deadTrap)
        {
            anim.SetBool("Death_Trap", true);
        }
       
    }
}
