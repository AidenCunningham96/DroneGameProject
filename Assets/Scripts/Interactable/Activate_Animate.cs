using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Animate : MonoBehaviour
{
    public Pressure_Plate plateScript;

    public Animator anim;
    bool activated;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (plateScript != null && plateScript.activated && !activated)
        {
            activated = true;
            anim.SetTrigger("Trigger");
        }
    }
}
