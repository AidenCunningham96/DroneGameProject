using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    Player_Switching playerSwitch;

    Rigidbody2D body;
    public float grabbedMass = 1;
    float ogMass;

    bool switchStatus;

    public float offset;

    public bool collidingWithGround;

    public bool canRotateFreely;

    //public GameObject bottomCollider;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerSwitch = GameObject.Find("GameManager").GetComponent<Player_Switching>();
        ogMass = body.mass;
    }

    public void Grabbed()
    {
        body.mass = grabbedMass;
    }

    public void ResetGrab()
    {
        body.mass = ogMass;
    }
}
