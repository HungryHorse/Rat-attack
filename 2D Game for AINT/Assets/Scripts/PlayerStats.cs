using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int health;
    public bool won;
    public float Knowledge;
    public bool hit;
    public bool shieldEnabled;
    public bool shieldIsOn;
    public float shieldTime;
    float currentShieldTime;
    public GameObject shield;
    public int isTutorial;

    public Image CooldownImage;
    public Text cooldownText;
    public float cooldown;
    public GameObject cooldownObject;
    float currentCooldownTime;


    public float iFrames;
    public float iFramesLeft;
    public GameObject win;
    public Image healthImage;
    public Text KnowledgeText;
    public GameObject GameOverScreen;

    private void Start()
    {
        isTutorial = PlayerPrefs.GetInt("Tutorial");

        iFramesLeft = 0;

        if (isTutorial != 1)
        {
            int chosenUpgrade = PlayerPrefs.GetInt("ActiveUpgrade");

            if (chosenUpgrade == 1)
            {
                EnableDisableShield(true);
            }
            else
            {
                EnableDisableShield(false);
            }

            if (chosenUpgrade == 2)
            {
                EnableDisableStunBomb(true);
            }
            else
            {
                EnableDisableStunBomb(false);
            }

            if (chosenUpgrade == 3)
            {
                EnableDisableDash(true);
            }
            else
            {
                EnableDisableDash(false);
            }

            if (chosenUpgrade == 4)
            {
                EnableDisableMinePooper(true);
            }
            else
            {
                EnableDisableMinePooper(false);
            }
        }
        else
        {
            EnableDisableMinePooper(false);
            EnableDisableDash(false);
            EnableDisableStunBomb(false);
            EnableDisableShield(false);
        }
    }

    public void EnableDisableShield(bool setValue)
    {
        shieldEnabled = setValue;
    }

    public void EnableDisableStunBomb(bool setValue)
    {
        gameObject.GetComponent<StunBomb>().enabled = setValue;
    }

    public void EnableDisableDash(bool setValue)
    {
        gameObject.GetComponent<Movement>().DashEnabled = setValue;
    }

    public void EnableDisableMinePooper(bool setValue)
    {
        gameObject.GetComponent<MinePooper>().enabled = setValue;
    }

    private void Update()
    {
        if (hit == true)
        {
            iFramesLeft = iFrames;
            hit = false;
        }

        if (iFramesLeft > 0)
        {
            iFramesLeft -= Time.deltaTime;
        }

        if (health <= 0)
        {
            KnowledgeText.text = "Knowledge collected this run: " + Knowledge;
            if (won)
            {
                win.SetActive(true);
            }
            GameOverScreen.SetActive(true);
            Destroy(gameObject);
        }

        if(healthImage.fillAmount >= health / 100.0f)
        {
            healthImage.fillAmount -= (0.3f * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && currentCooldownTime <= 0 && shieldEnabled)
        {
            cooldownObject.SetActive(true);
            currentShieldTime = shieldTime;
            CooldownImage.fillAmount = 1;
            currentCooldownTime = cooldown;
        }

        if (currentShieldTime >= 0)
        {
            shieldIsOn = true;
            currentShieldTime -= 1.0f * Time.deltaTime;
        }
        else
        {
            shieldIsOn = false;
        }

        shield.SetActive(shieldIsOn);

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
}
