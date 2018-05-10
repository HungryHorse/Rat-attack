using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    int knowledge;
    public Text knowledgeText;
    int cooldownPrice;
    int timePrice;
    int HOTPrice;

	// Use this for initialization
	void Start () {
        knowledge = PlayerPrefs.GetInt("Knowledge", 0); 
        cooldownPrice = 20;
        timePrice = 25;
        HOTPrice = 25;



        if (!PlayerPrefs.HasKey("CooldownUpgrade"))
        {
            PlayerPrefs.SetInt("CooldownUpgrade", 0);
        }
        if (!PlayerPrefs.HasKey("TimeUpgrade"))
        {
            PlayerPrefs.SetInt("TimeUpgrade", 0);
        }
        if (!PlayerPrefs.HasKey("HOT"))
        {
            PlayerPrefs.SetInt("HOT", 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        knowledgeText.text = "Knowledge fragments: " + knowledge.ToString();
    }


    public void OnUpgradeCooldown ()
    {
        if (PlayerPrefs.GetInt("CooldownUpgrade") < 5 && knowledge > cooldownPrice)
        {
            PlayerPrefs.SetInt("CooldownUpgrade", PlayerPrefs.GetInt("CooldownUpgrade") + 1);
        }
    }

    public void OnUpgradeTime()
    {

        if (PlayerPrefs.GetInt("TimeUpgrade") < 5 && knowledge > timePrice)
        {
            PlayerPrefs.SetInt("TimeUpgrade", PlayerPrefs.GetInt("TimeUpgrade") + 1);
        }
    }

    public void OnUpgradeHOT()
    {

        if (PlayerPrefs.GetInt("HOT") < 1 && knowledge > HOTPrice)
        {
            PlayerPrefs.SetInt("HOT", 1);
        }
    }
}
