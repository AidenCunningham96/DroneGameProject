using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    //public Grabbable grabbableScript;
    public GameObject grabbableObj;
    Rigidbody2D grabbableBody;

    public bool Grabbed;

    void OnDisable()
    {
        Grabbed = false;

        if (grabbableBody != null)
        {
            grabbableBody.bodyType = RigidbodyType2D.Dynamic;
        }
        if (grabbableObj != null)
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
            grabbableObj.layer = LayerIgnoreRaycast;
            grabbableObj.transform.parent = null;

        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbableObj != null)
            {
                if (!Grabbed)
                {
                    Invoke("Grab", .02f);
                }
                else
                {
                    Invoke("Release", .02f);
                }            
            }
        }
    }

    void Grab()
    {
        Grabbed = true;
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore_Player");
        grabbableObj.layer = LayerIgnoreRaycast;
        grabbableBody.bodyType = RigidbodyType2D.Kinematic;
        grabbableObj.transform.rotation = Quaternion.identity;
        grabbableObj.transform.position = transform.position;
        grabbableObj.transform.parent = this.transform;
    }

    void Release()
    {
        Grabbed = false;
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
        grabbableObj.layer = LayerIgnoreRaycast;
        grabbableObj.transform.parent = null;
        grabbableBody.bodyType = RigidbodyType2D.Dynamic;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            //grabbableScript = col.gameObject.GetComponent<Grabbable>();
            grabbableObj = col.gameObject;
            grabbableBody = col.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            //grabbableScript = null;
            grabbableObj = null;
        }
    }
}
