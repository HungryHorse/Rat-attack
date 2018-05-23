using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    float speed;
    public bool DashEnabled;
    public float walkSpeed;
    public float dashSpeed;
    public float dashTimer;
    float currentDashTime;
    Rigidbody2D rigidbody2D;
    public Animator animator;
    public PlayerStats player;
    public GameObject audioManager;

    public Image CooldownImage;
    public Text cooldownText;
    public float cooldown;
    public GameObject cooldownObject;
    float currentCooldownTime;

    void Start()
    {
        speed = walkSpeed;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(x != 0 || y != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;
    }

    // All functions that take level as argument are used to upgrade the dash ability based on what was bought in the upgrade store 
    public void SpeedIncrease(int level)
    {
        switch (level)
        {
            case (1):
                dashSpeed += (dashSpeed * 0.05f);
                break;
            case (2):
                dashSpeed += (dashSpeed * 0.1f);
                break;
            case (3):
                dashSpeed += (dashSpeed * 0.15f);
                break;
            case (4):
                dashSpeed += (dashSpeed * 0.2f);
                break;
            case (5):
                dashSpeed += (dashSpeed * 0.25f);
                break;
            default:
                break;
        }
    }

    public void ResistanceIncrease(int level)
    {
        switch (level)
        {
            case (1):
                player.resistance = 0.95f;
                break;
            case (2):
                player.resistance = 0.90f;
                break;
            case (3):
                player.resistance = 0.85f;
                break;
            case (4):
                player.resistance = 0.80f;
                break;
            case (5):
                player.resistance = 0.75f;
                break;
            default:
                player.resistance = 1f;
                break;
        }
    }

    public void TimeIncrease(int level)
    {
        switch (level)
        {
            case (1):
                dashTimer += (dashTimer * 0.05f);
                break;
            case (2):
                dashTimer += (dashTimer * 0.1f);
                break;
            case (3):
                dashTimer += (dashTimer * 0.15f);
                break;
            case (4):
                dashTimer += (dashTimer * 0.2f);
                break;
            case (5):
                dashTimer += (dashTimer * 0.25f);
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

    void Update()
    {
        // Handles the useage and cooldown of the dash ability
        if (Input.GetButtonDown("Jump") && currentCooldownTime <= 0 && DashEnabled)
        {
            audioManager.GetComponent<AudioController>().PlayDashSound();
            cooldownObject.SetActive(true);
            CooldownImage.fillAmount = 1;
            speed = dashSpeed;
            currentCooldownTime = cooldown;
            currentDashTime = dashTimer;
        }

        if (currentDashTime >= 0)
        {
            currentDashTime -= 1.0f * Time.deltaTime;
        }
        else
        {
            speed = walkSpeed;
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
}
