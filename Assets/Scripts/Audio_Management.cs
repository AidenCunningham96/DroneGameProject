using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Management : MonoBehaviour
{
    AudioSource droneFlying;
    bool droneFly;
    AudioSource kidFootsteps;
    bool kidWalk;

    Drone_Controller droneCon;
    Boy_Controller boyCon;

    // Start is called before the first frame update
    void Awake()
    {
        droneCon = GameObject.Find("Drone").GetComponent<Drone_Controller>();
        droneFlying = GameObject.Find("Drone").GetComponent<AudioSource>();

        boyCon = GameObject.Find("Boy").GetComponent<Boy_Controller>();
        kidFootsteps = GameObject.Find("Boy").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!droneFly && droneCon.enabled)
        {
            droneFly = true;
            droneFlying.Play();
        }

        if (droneFly && !droneCon.enabled)
        {
            Invoke("DisableDroneSound", .1f);
        }

        if (!kidWalk && boyCon.horizontal != 0 && boyCon.isGrounded)
        {
            kidWalk = true;
            kidFootsteps.Play();
        }

        if (kidWalk && boyCon.horizontal == 0 || kidWalk && !boyCon.isGrounded)
        {
            Invoke("DisableKidWalkSound", .1f);
        }
    }

    void DisableDroneSound()
    {
        droneFly = false;
        droneFlying.Stop();
    }

    void DisableKidWalkSound()
    {
        kidWalk = false;
        kidFootsteps.Stop();
    }
}
