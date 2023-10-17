using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    Player_Switching playerSwitch;

    Rigidbody2D body;

    bool switchStatus;

    public float offset;

    public bool collidingWithGround;

    public GameObject bottomCollider;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerSwitch = GameObject.Find("GameManager").GetComponent<Player_Switching>();
    }

    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //    {
    //        collidingWithGround = true;
    //    }
    //}

    //void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //    {
    //        collidingWithGround = false;
    //    }
    //}
}
