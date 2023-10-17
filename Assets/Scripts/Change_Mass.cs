using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Mass : MonoBehaviour
{
    Player_Switching playerSwitch;
    Rigidbody2D body;

    bool changeMass;

    float ogMass;

    // Start is called before the first frame update
    void Start()
    {
        playerSwitch = GameObject.Find("GameManager").GetComponent<Player_Switching>();
        body = GetComponent<Rigidbody2D>();
        ogMass = body.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSwitch.selectedPlayerNumber == 1 && !changeMass)
        {
            changeMass = true;
            body.mass = 1000;
        }

        if (playerSwitch.selectedPlayerNumber == 0 && changeMass)
        {
            Invoke("Reset", 1f);
            body.mass = ogMass;
        }
    }

    void Reset()
    {
        changeMass = false;
    }
}
