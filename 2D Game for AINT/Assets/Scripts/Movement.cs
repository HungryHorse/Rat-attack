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

    void Update()
    {
        if (Input.GetButtonDown("Jump") && currentCooldownTime <= 0 && DashEnabled)
        {
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
