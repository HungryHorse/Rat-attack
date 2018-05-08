using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunBomb : MonoBehaviour {

    CircleCollider2D thisCollider;
    bool Used;
    GameObject targetHit;
    public Image CooldownImage;
    public Text cooldownText;
    public float cooldown;
    public bool doesDamage;
    public int rateOfIncrease;
    public float stunTime;
    public float maxRadius;
    public GameObject cooldownObject;
    float currentCooldownTime;


    // Use this for initialization
    void Start () {
        CooldownImage.fillAmount = 0;
        thisCollider = gameObject.GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump") && currentCooldownTime <= 0)
        {
            cooldownObject.SetActive(true);
            CooldownImage.fillAmount = 1;
            Used = true;
            currentCooldownTime = cooldown;
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

    void TimeIncrease(int level)
    {
        switch (level)
        {
            case (1):
                stunTime += (stunTime * 0.05f);
                break;
            case (2):
                stunTime += (stunTime * 0.1f);
                break;
            case (3):
                stunTime += (stunTime * 0.15f);
                break;
            case (4):
                stunTime += (stunTime * 0.2f);
                break;
            case (5):
                stunTime += (stunTime * 0.25f);
                break;
            default:
                break;
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

    void RadiusIncrease(int level)
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

    void FixedUpdate()
    {
        if (Used)
        {
            thisCollider.radius += (rateOfIncrease * 0.01f);
        }
        
        if (thisCollider.radius >= maxRadius)
        {
            Used = false;
            thisCollider.radius = 0.001f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetHit = collision.gameObject;
        if (targetHit.tag == "Enemy")
        {
            targetHit.GetComponent<Enemy>().stunRemaining = stunTime;
        }
    }
}
