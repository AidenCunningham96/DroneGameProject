using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate : MonoBehaviour
{
    [HideInInspector]
    public bool activated, triggered;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !activated)
        {
            activated = true;

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            //interactPrompt.enabled = true;
            triggered = true;
            anim.SetTrigger("Trigger");
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            anim.SetTrigger("Trigger");
        }

    }
}
