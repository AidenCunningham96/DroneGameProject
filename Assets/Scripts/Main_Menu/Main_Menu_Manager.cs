using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu_Manager : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject creditsMenu;
    public GameObject mainMenu;
    public GameObject confirmMenu;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Fade_Canvas").GetComponent<Animator>();
    }

    public void NewGame()
    {
        anim.Play("Fade_Out");
        Invoke("StartNewGame", .5f);
        
    }
    void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        Debug.Log("Game will load last checkpoint here");
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void CloseCredits()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
