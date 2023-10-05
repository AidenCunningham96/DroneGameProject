using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool onLadder;
    public bool leftFacingLadder;
    bool ladderCheck;
    bool canClimb;

    public Transform ladderPosition;

    Boy_Controller boyCon;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Boy");
        boyCon = Player.GetComponent<Boy_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canClimb)
        {
            if (boyCon.Climbing && !ladderCheck)
            {
                //topFloor.enabled = false;
                //topBarrier.SetActive(true);
                //interactPrompt.enabled = false;
                Player.transform.position = new Vector3(ladderPosition.transform.position.x, Player.transform.position.y, Player.transform.position.z);

                if (boyCon.facingRight && leftFacingLadder)
                {
                    boyCon.Flip();
                    boyCon.facingRight = false;
                }
                if (!boyCon.facingRight && !leftFacingLadder)
                {
                    boyCon.Flip();
                    boyCon.facingRight = true;
                }

                onLadder = true;
                ladderCheck = true;
            }
            if (!boyCon.Climbing && ladderCheck)
            {
                //topBarrier.SetActive(false);
                //topFloor.enabled = true;

                onLadder = false;
                ladderCheck = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boy")
        {
            //interactPrompt.enabled = true;
            canClimb = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boy")
        {
            //interactPrompt.enabled = false;
            canClimb = false;
        }

    }
}
