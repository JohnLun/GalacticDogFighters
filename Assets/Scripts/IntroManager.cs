using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject game;
    public GameObject intro;
    public GameObject controls;
    // Start is called before the first frame update
    void Start()
    {
        game.SetActive(false);
        controls.SetActive(false);
        intro.SetActive(true);
        SoundManager.PlaySound("ambient");
    }

    public void onClickQuit()
    {
        Application.Quit();
    }

    public void onClickPlay()
    {
        game.SetActive(true);
        intro.SetActive(false);
        SoundManager.PauseSound("ambient");
    }

    public void onClickControls()
    {
        controls.SetActive(true);
        intro.SetActive(false);
    }

    public void onClickBack()
    {
        intro.SetActive(true);
        controls.SetActive(false);
        game.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
