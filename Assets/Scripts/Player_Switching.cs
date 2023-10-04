using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Switching : MonoBehaviour
{
    GameObject selectedPlayerTarget;
    public GameObject selectedPlayer;
    public int selectedPlayerNumber;

    public List<GameObject> playableCharacters = new List<GameObject>();

    Boy_Controller boyCon;
    Drone_Controller droneCon;

    bool assignCheck;

    // Start is called before the first frame update
    void Start()
    {
        
        playableCharacters.Add(GameObject.FindWithTag("Boy"));
        boyCon = GameObject.FindWithTag("Boy").GetComponent<Boy_Controller>();

        playableCharacters.Add(GameObject.FindWithTag("Drone"));
        droneCon = GameObject.FindWithTag("Drone").GetComponent<Drone_Controller>();

        selectedPlayerTarget = GameObject.Find("Selected_Player_Target");

        selectedPlayer = playableCharacters[0];
 
    }

    // Update is called once per frame
    void Update()
    {
        if (!assignCheck)
        {
            assignCheck = true;
            droneCon.enabled = false;
        }
        selectedPlayerTarget.transform.position = new Vector3(selectedPlayer.transform.position.x, selectedPlayer.transform.position.y, selectedPlayerTarget.transform.position.z);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {          
            Invoke("SwitchPlayers", .05f);
        }
    }

    void SwitchPlayers()
    {
        if (selectedPlayerNumber != playableCharacters.Count)
        {
            selectedPlayerNumber++;
            boyCon.enabled = false;
            droneCon.enabled = true;
        }

        if (selectedPlayerNumber >= playableCharacters.Count)
        {
            selectedPlayerNumber = 0;
            boyCon.enabled = true;
            droneCon.enabled = false;
        }

        selectedPlayer = playableCharacters[selectedPlayerNumber];
    }
}
