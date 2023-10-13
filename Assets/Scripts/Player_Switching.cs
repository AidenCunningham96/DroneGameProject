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
    Rigidbody2D boyBody;
    Boy_Animator boyAnimScript;

    Drone_Controller droneCon;
    Drone_Animator droneAnimScript;
    Grabber grabScript;

    bool assignCheck;
    [HideInInspector]
    public  bool Switching;

    private Player_Controls controls;

    void Awake()
    {
        controls = new Player_Controls();
        controls.General.Switch.performed += ctx => SwitchPlayers();
    }

    void OnEnable()
    {
        controls.General.Enable();
    }
    void OnDisable()
    {
        controls.General.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        playableCharacters.Add(GameObject.FindWithTag("Boy"));
        boyBody = GameObject.FindWithTag("Boy").GetComponent<Rigidbody2D>();
        boyCon = GameObject.FindWithTag("Boy").GetComponent<Boy_Controller>();
        boyAnimScript = GameObject.FindWithTag("Boy").GetComponent<Boy_Animator>();

        playableCharacters.Add(GameObject.FindWithTag("Drone"));
        droneCon = GameObject.FindWithTag("Drone").GetComponent<Drone_Controller>();
        droneAnimScript = GameObject.FindWithTag("Drone").GetComponent<Drone_Animator>();
        grabScript = GameObject.Find("Grab_Point").GetComponent<Grabber>();

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
            grabScript.enabled = false;
        }
        selectedPlayerTarget.transform.position = new Vector3(selectedPlayer.transform.position.x, selectedPlayer.transform.position.y, selectedPlayerTarget.transform.position.z);

    }

    void SwitchPlayers()
    {
        Switching = true;
        Invoke("ResetSwitchBool", .2f);

        if (selectedPlayerNumber != playableCharacters.Count)
        {
            selectedPlayerNumber++;
            boyCon.enabled = false;
            boyBody.gravityScale = 20;
            boyAnimScript.anim.SetBool("Walk", false);
            boyAnimScript.anim.SetBool("Fall", false);
            boyAnimScript.anim.SetBool("Drone", true);
            boyAnimScript.anim.SetBool("Death_Trap", false);
            boyAnimScript.anim.SetBool("Jump", false);
            boyAnimScript.anim.SetBool("Pushing", false);
            droneCon.enabled = true;
            grabScript.enabled = true;
        }

        if (selectedPlayerNumber >= playableCharacters.Count)
        {
            selectedPlayerNumber = 0;
            boyCon.enabled = true;
            boyBody.gravityScale = 1;
            droneCon.flying = false;
            droneCon.enabled = false;
            droneAnimScript.anim.SetBool("Flight", false);
            droneAnimScript.anim.SetBool("Grab", false);
            grabScript.enabled = false;
        }

        selectedPlayer = playableCharacters[selectedPlayerNumber];
    }

    void ResetSwitchBool()
    {
        Switching = false;
    }
}
