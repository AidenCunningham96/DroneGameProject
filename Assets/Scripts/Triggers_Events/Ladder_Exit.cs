using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Exit : MonoBehaviour
{
    public bool exitingLadder;
    public GameObject exitTarget;
    Boy_Controller boyCon;
    GameObject player;

    void Start()
    {
        boyCon = GameObject.FindWithTag("Boy").GetComponent<Boy_Controller>();
        player = GameObject.FindWithTag("Boy");
    }
    void Update()
    {
        if (exitingLadder)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, exitTarget.transform.position, 5 * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boy" && boyCon.Climbing)
        {
            exitingLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boy")
        {
            exitingLadder = false;
        }
    }
}
