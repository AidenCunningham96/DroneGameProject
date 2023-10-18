using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    Grabbable grabbableScript;
    public GameObject grabbableObj;
    Rigidbody2D grabbableBody;

    public bool Grabbed, tryingGrab;

    void OnDisable()
    {
        Grabbed = false;

        if (grabbableBody != null)
        {
            grabbableBody.bodyType = RigidbodyType2D.Dynamic;
        }
        if (grabbableObj != null)
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Ground");
            grabbableObj.layer = LayerIgnoreRaycast;
            grabbableObj.transform.parent = null;

        }
        
    }

    public void TryGrab()
    {
        if (!Grabbed)
        {
            tryingGrab = true;
        }
        

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
        else
        {
            Invoke("GrabFailed", .6f);
        }
    }

    void Update()
    {
        if (Grabbed)
        {
            grabbableObj.transform.rotation = Quaternion.identity;
        }
    }

    void GrabFailed()
    {
        tryingGrab = false;
    }

    void Grab()
    {
        Grabbed = true;
        tryingGrab = false;
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore_Player");
        grabbableObj.layer = LayerIgnoreRaycast;

        grabbableObj.transform.rotation = Quaternion.identity;
        //grabbableScript.bottomCollider.SetActive(true);
        grabbableObj.transform.position = new Vector3(transform.position.x, transform.position.y - grabbableScript.offset, transform.position.z);

        grabbableBody.bodyType = RigidbodyType2D.Kinematic;

        grabbableObj.transform.parent = this.transform;
    }

    public void Release()
    {
        Grabbed = false;
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ground");
        grabbableObj.layer = LayerIgnoreRaycast;
        grabbableObj.transform.parent = null;
        grabbableBody.bodyType = RigidbodyType2D.Dynamic;
        //grabbableScript.bottomCollider.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            grabbableScript = col.gameObject.GetComponent<Grabbable>();
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
