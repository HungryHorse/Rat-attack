﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject PauseMenu;
    public GameObject GunRight;
    public GameObject GunLeft;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }

        if (PauseMenu.activeInHierarchy)
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
}
