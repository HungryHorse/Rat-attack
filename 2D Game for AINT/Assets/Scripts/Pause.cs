using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject PauseMenu;
    public GameObject SoundOptions;
    public GameObject GunRight;
    public GameObject GunLeft;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {

        // allows you to open the pause menu in game by pressing ESC
        // or if the sound options is open will return you to the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
            SoundOptions.SetActive(false);
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }

        if (PauseMenu.activeInHierarchy || SoundOptions.activeInHierarchy)
        {
            GunLeft.SetActive(false);
            GunRight.SetActive(false);
        }
        else
        {
            GunLeft.SetActive(true);
            GunRight.SetActive(true);
        }
	}

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        PauseMenu.SetActive(false);
        SoundOptions.SetActive(true);
    }

    public void Back()
    {
        PauseMenu.SetActive(true);
        SoundOptions.SetActive(false);
    }
}
