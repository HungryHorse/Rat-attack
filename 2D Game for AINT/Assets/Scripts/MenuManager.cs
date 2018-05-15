using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject Options;


    public void TurnOnOptions()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }
}
