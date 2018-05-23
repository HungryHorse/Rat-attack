using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    int knowledge;
    public Text knowledgeText;
    int tierOnePrice;
    int tierTwoPrice;
    int tierThreePrice;
    int tierFourPrice;

	// Use this for initialization
	void Start () {
        knowledge = PlayerPrefs.GetInt("Knowledge", 0);
        tierOnePrice = 20;
        tierTwoPrice = 30;

        // This huge list just makes sure all the player prefs for the upgrades are set up correctly
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
        if (!PlayerPrefs.HasKey("stunCooldown"))
        {
            PlayerPrefs.SetInt("stunCooldown", 0);
        }
        if (!PlayerPrefs.HasKey("lengthOfStun"))
        {
            PlayerPrefs.SetInt("lengthOfStun", 0);
        }
        if (!PlayerPrefs.HasKey("stunDoesDamage"))
        {
            PlayerPrefs.SetInt("stunDoesDamage", 0);
        }
        if (!PlayerPrefs.HasKey("stunRadius"))
        {
            PlayerPrefs.SetInt("stunRadius", 0);
        }
        if (!PlayerPrefs.HasKey("dashCooldown"))
        {
            PlayerPrefs.SetInt("dashCooldown", 0);
        }
        if (!PlayerPrefs.HasKey("dashSpeed"))
        {
            PlayerPrefs.SetInt("dashSpeed", 0);
        }
        if (!PlayerPrefs.HasKey("lengthOfDash"))
        {
            PlayerPrefs.SetInt("lengthOfDash", 0);
        }
        if (!PlayerPrefs.HasKey("reduceDamage"))
        {
            PlayerPrefs.SetInt("reduceDamage", 0);
        }
        if (!PlayerPrefs.HasKey("mineCooldown"))
        {
            PlayerPrefs.SetInt("mineCooldown", 0);
        }
        if (!PlayerPrefs.HasKey("damageIncrease"))
        {
            PlayerPrefs.SetInt("damageIncrease", 0);
        }
        if (!PlayerPrefs.HasKey("mineRadius"))
        {
            PlayerPrefs.SetInt("mineRadius", 0);
        }
        if (!PlayerPrefs.HasKey("mineCharges"))
        {
            PlayerPrefs.SetInt("mineCharges", 0);
        }


    }
	
	void Update () {
        knowledgeText.text = "Knowledge fragments: " + knowledge.ToString();
    }

    // when the scene changes the object is destroyed and this sets the player pref containing how much knowledge you have is updated 
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Knowledge", knowledge);
    }

    // These set the level of each upgrade in player prefs and handel the buying of the upgrades where knowledge is used as a currency
    public void OnUpgradeCooldown ()
    {
        if (PlayerPrefs.GetInt("CooldownUpgrade") < 5 && knowledge > tierOnePrice)
        {
            PlayerPrefs.SetInt("CooldownUpgrade", PlayerPrefs.GetInt("CooldownUpgrade") + 1);
            knowledge -= tierOnePrice;
        }
    }

    public void OnUpgradeTime()
    {

        if (PlayerPrefs.GetInt("TimeUpgrade") < 5 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("TimeUpgrade", PlayerPrefs.GetInt("TimeUpgrade") + 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeHOT()
    {

        if (PlayerPrefs.GetInt("HOT") < 1 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("HOT", 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeStunCooldown()
    {

        if (PlayerPrefs.GetInt("stunCooldown") < 5 && knowledge > tierOnePrice)
        {
            PlayerPrefs.SetInt("stunCooldown", PlayerPrefs.GetInt("stunCooldown") + 1);
            knowledge -= tierOnePrice;
        }
    }

    public void OnUpgradeStunLength()
    {

        if (PlayerPrefs.GetInt("lengthOfStun") < 5 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("lengthOfStun", PlayerPrefs.GetInt("lengthOfStun") + 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeStunDamage()
    {

        if (PlayerPrefs.GetInt("stunDoesDamage") < 1 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("stunDoesDamage", 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeStunRadius()
    {

        if (PlayerPrefs.GetInt("stunRadius") < 5 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("stunRadius", PlayerPrefs.GetInt("stunRadius") + 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeDashCooldown()
    {
        if (PlayerPrefs.GetInt("dashCooldown") < 5 && knowledge > tierOnePrice)
        {
            PlayerPrefs.SetInt("dashCooldown", PlayerPrefs.GetInt("dashCooldown") + 1);
            knowledge -= tierOnePrice;
        }
    }

    public void OnUpgradeDashSpeed()
    {

        if (PlayerPrefs.GetInt("dashSpeed") < 5 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("dashSpeed", PlayerPrefs.GetInt("dashSpeed") + 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeDashLength()
    {

        if (PlayerPrefs.GetInt("lengthOfDash") < 5 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("lengthOfDash", PlayerPrefs.GetInt("lengthOfDash") + 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeReduceDamage()
    {

        if (PlayerPrefs.GetInt("reduceDamage") < 5 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("reduceDamage", PlayerPrefs.GetInt("reduceDamage") + 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeMineCooldown()
    {

        if (PlayerPrefs.GetInt("mineCooldown") < 5 && knowledge > tierOnePrice)
        {
            PlayerPrefs.SetInt("mineCooldown", PlayerPrefs.GetInt("mineCooldown") + 1);
            knowledge -= tierOnePrice;
        }
    }

    public void OnUpgradeIncreaseDamage()
    {

        if (PlayerPrefs.GetInt("damageIncrease") < 5 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("damageIncrease", PlayerPrefs.GetInt("damageIncrease") + 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeMineRadius()
    {

        if (PlayerPrefs.GetInt("mineRadius") < 5 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("mineRadius", PlayerPrefs.GetInt("mineRadius") + 1);
            knowledge -= tierTwoPrice;
        }
    }

    public void OnUpgradeMineCharges()
    {

        if (PlayerPrefs.GetInt("mineCharges") < 3 && knowledge > tierTwoPrice)
        {
            PlayerPrefs.SetInt("mineCharges", PlayerPrefs.GetInt("mineCharges") + 1);
            knowledge -= tierTwoPrice;
        }
    }
}
