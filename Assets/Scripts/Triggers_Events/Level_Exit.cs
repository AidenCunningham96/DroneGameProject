using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Exit : MonoBehaviour
{
    public float sceneChangeTime = 1f;

    Animator fadeAnim;

    void Start()
    {
        fadeAnim = GameObject.Find("Fade_Canvas").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boy")
        {
            fadeAnim.Play("Fade_Out");
            Invoke("NextLevel", sceneChangeTime);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
