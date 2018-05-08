using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (!PlayerPrefs.HasKey("CooldownUpgrade"))
        {
            PlayerPrefs.SetInt("CooldownUpgrade", 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnUpgradeCooldown ()
    {
        print("cooldown upgraded");
        if (PlayerPrefs.GetInt("CooldownUpgrade") < 5)
        {
            PlayerPrefs.SetInt("CooldownUpgrade", PlayerPrefs.GetInt("CooldownUpgrade") + 1);
        }
    }
}
