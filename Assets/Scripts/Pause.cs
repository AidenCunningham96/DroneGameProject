using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;
    GameObject pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("Pause_Menu_Canvas");
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if (gameIsPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }
    public void Resume()
    {
        gameIsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    public void QuitGame()
    {
        Debug.Log("Game has been quit");
        Application.Quit();
    }
}
