using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    Player_Switching playerSwitch;

    Rigidbody2D body;

    bool switchStatus;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerSwitch = GameObject.Find("GameManager").GetComponent<Player_Switching>();
    }

    void Update()
    {
        //if (!switchStatus)
        //{
        //    switchStatus = true;

        //    if (playerSwitch.selectedPlayerNumber == 1)
        //    {
        //        body.bodyType = RigidbodyType2D.Dynamic;
        //    }
        //    else
        //    {
        //        body.bodyType = RigidbodyType2D.Kinematic;
        //    }
        //}

        //if (switchStatus && playerSwitch.Switching)
        //{
        //    switchStatus = false;
        //}
        
    }
}
