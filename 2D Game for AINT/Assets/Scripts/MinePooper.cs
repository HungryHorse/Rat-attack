using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinePooper : MonoBehaviour {

    public GameObject MineSpawner;
    public GameObject Mine;
    public Image CooldownImage;
    public Text cooldownText;
    public float cooldown;
    public float damage;
    public int extraCharges;
    public float maxRadius;
    public GameObject cooldownObject;
    public GameObject audioManager;
    float currentCooldownTime;

	// Use this for initialization
	void Start () {
        MineSpawner = GameObject.Find("MineSpawner");
        CooldownImage.fillAmount = 0;
	}

    private void OnEnable()
    {
        extraCharges = PlayerPrefs.GetInt("mineCharges");
    }

    // Update is called once per frame
    void Update () {

        // Handles the useage and cooldown of the mine pooper ability
        if (Input.GetButtonDown("Jump") && currentCooldownTime <= 0)
        {
            audioManager.GetComponent<AudioController>().PlayShotSound();
            cooldownObject.SetActive(true);
            CooldownImage.fillAmount = 1;
            GameObject newMine = Instantiate(Mine, gameObject.transform.position, gameObject.transform.rotation);
            newMine.GetComponent<Mines>().damage = damage;
            newMine.GetComponent<Mines>().maxRadius = maxRadius;
            currentCooldownTime = cooldown;
        }
        else
        {
            if(Input.GetButtonDown("Jump") && extraCharges > 0) // this is used to check if they have the extra charges upgrade as it is not affected by a cooldown
            {
                audioManager.GetComponent<AudioController>().PlayMinePooperSound();
                extraCharges--;
                GameObject newMine = Instantiate(Mine, gameObject.transform.position, gameObject.transform.rotation);
                newMine.GetComponent<Mines>().damage = damage;
                newMine.GetComponent<Mines>().maxRadius = maxRadius;
            }
        }

        if (currentCooldownTime >= 0)
        {
            cooldownText.text = string.Format("{0:N1}", currentCooldownTime);
            currentCooldownTime -= 1.0f * Time.deltaTime;
            CooldownImage.fillAmount -= 1.0f / cooldown * Time.deltaTime;
        }
        else
        {
            cooldownObject.SetActive(false);
            cooldownText.text = "";
        }
	}

    // All functions that take level as argument are used to upgrade the mine pooper ability based on what was bought in the upgrade store 
    public void DamageIncrease(int level)
    {
        switch (level)
        {
            case (1):
                damage += (damage * 0.05f);
                break;
            case (2):
                damage += (damage * 0.1f);
                break;
            case (3):
                damage += (damage * 0.15f);
                break;
            case (4):
                damage += (damage * 0.2f);
                break;
            case (5):
                damage += (damage * 0.25f);
                break;
            default:
                break;
        }
    }

    public void RadiusIncrease(int level)
    {
        switch (level)
        {
            case (1):
                maxRadius += (maxRadius * 0.05f);
                break;
            case (2):
                maxRadius += (maxRadius * 0.1f);
                break;
            case (3):
                maxRadius += (maxRadius * 0.15f);
                break;
            case (4):
                maxRadius += (maxRadius * 0.2f);
                break;
            case (5):
                maxRadius += (maxRadius * 0.25f);
                break;
            default:
                break;
        }
    }

    public void CoolDownReduc(int level)
    {
        switch (level)
        {
            case (1):
                cooldown -= (cooldown * 0.05f);
                break;
            case (2):
                cooldown -= (cooldown * 0.1f);
                break;
            case (3):
                cooldown -= (cooldown * 0.15f);
                break;
            case (4):
                cooldown -= (cooldown * 0.2f);
                break;
            case (5):
                cooldown -= (cooldown * 0.25f);
                break;
            default:
                break;
        }
    }
}
