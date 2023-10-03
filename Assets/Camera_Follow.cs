using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public GameObject playerObject;
    public bool droneIsDeployed;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Boy"); // The player
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + 5, playerObject.transform.position.z - 10);
        if(droneIsDeployed == true)
        {
            playerObject = GameObject.Find("Player"); // The player
        }
    }
}
