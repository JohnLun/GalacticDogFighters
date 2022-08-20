using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    private bool paused = false;
    public GameObject pauseMenu;
    public GameObject game;
    public GameObject intro;
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            paused = !paused;
        }
    }
    public void onQuit()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        game.SetActive(false);
        intro.SetActive(true);
        SoundManager.PlaySound("ambient");
    }
}
