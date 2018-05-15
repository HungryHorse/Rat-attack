using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public float health;
    public float resistance = 1;
    public bool won;
    public int Knowledge;
    public bool hit;
    public bool shieldEnabled;
    public bool shieldIsOn;
    public float shieldTime;
    float currentShieldTime;
    public GameObject shield;
    public int isTutorial;
    public GameObject audioManager;

    public Image CooldownImage;
    public Text cooldownText;
    public float cooldown;
    public GameObject cooldownObject;
    float currentCooldownTime;
    public bool HOTActive;


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
        currentShieldTime = -0.1f;
        resistance = 1;

        if (isTutorial != 1)
        {
            int chosenUpgrade = PlayerPrefs.GetInt("ActiveUpgrade");

            if (chosenUpgrade == 1)
            {
                EnableDisableShield(true);
                CoolDownReduc(PlayerPrefs.GetInt("CooldownUpgrade"));
                TimeIncrease(PlayerPrefs.GetInt("TimeUpgrade"));
                if(PlayerPrefs.GetInt("HOT") == 1)
                {
                    HOTActive = true;
                }
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
        StunBomb stun = gameObject.GetComponent<StunBomb>();
        stun.enabled = setValue;
        if (setValue)
        {
            stun.CoolDownReduc(PlayerPrefs.GetInt("stunCooldown"));
            stun.TimeIncrease(PlayerPrefs.GetInt("lengthOfStun"));
            if (PlayerPrefs.GetInt("stunDoesDamage") == 1)
            {
                stun.doesDamage = true;
            }
            stun.RadiusIncrease(PlayerPrefs.GetInt("stunRadius"));
        }
    }

    public void EnableDisableDash(bool setValue)
    {
        Movement move = gameObject.GetComponent<Movement>();
        move.DashEnabled = setValue;
        if (setValue)
        {
            move.ResistanceIncrease(PlayerPrefs.GetInt("reduceDamage"));
            move.CoolDownReduc(PlayerPrefs.GetInt("dashCooldown"));
            move.SpeedIncrease(PlayerPrefs.GetInt("dashSpeed"));
            move.TimeIncrease(PlayerPrefs.GetInt("lengthOfDash"));
        }
    }

    public void EnableDisableMinePooper(bool setValue)
    {
        MinePooper mine = gameObject.GetComponent<MinePooper>();
        mine.enabled = setValue;
        if (setValue)
        {
            mine.CoolDownReduc(PlayerPrefs.GetInt("mineCooldown"));
            mine.DamageIncrease(PlayerPrefs.GetInt("damageIncrease"));
            mine.RadiusIncrease(PlayerPrefs.GetInt("mineRadius"));
        }
    }
    void CoolDownReduc(int level)
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

    void TimeIncrease(int level)
    {
        switch (level)
        {
            case (1):
                shieldTime += (shieldTime * 0.05f);
                break;
            case (2):
                shieldTime += (shieldTime * 0.1f);
                break;
            case (3):
                shieldTime += (shieldTime * 0.15f);
                break;
            case (4):
                shieldTime += (shieldTime * 0.2f);
                break;
            case (5):
                shieldTime += (shieldTime * 0.25f);
                break;
            default:
                break;
        }
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
            audioManager.GetComponent<AudioController>().PlayPlayerDeathSound();
            KnowledgeText.text = "Knowledge collected this run: " + Knowledge;
            PlayerPrefs.SetInt("Knowledge", PlayerPrefs.GetInt("Knowledge") + Knowledge);
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

        if (healthImage.fillAmount <= health / 100.0f)
        {
            healthImage.fillAmount += (0.3f * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && currentCooldownTime <= 0 && shieldEnabled)
        {
            audioManager.GetComponent<AudioController>().PlayShieldApplySound();
            cooldownObject.SetActive(true);
            currentShieldTime = shieldTime;
            CooldownImage.fillAmount = 1;
            currentCooldownTime = cooldown;
        }

        if (HOTActive)
        {
            health += 0.1f * Time.deltaTime;
        }

        if (currentShieldTime >= 0 && currentShieldTime <= 0.02)
        {
            audioManager.GetComponent<AudioController>().PlayShieldDecaySound();
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
