using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_Release_Grab : MonoBehaviour
{
    Grabber grabberScript;

    public GameObject grabbableObj;

    // Start is called before the first frame update
    void Start()
    {
        grabberScript = GameObject.FindWithTag("Grabber").GetComponent<Grabber>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            if (grabberScript.grabbableObj == grabbableObj)
            {
                grabberScript.Release();
            }
            
        }
    }

    
}
