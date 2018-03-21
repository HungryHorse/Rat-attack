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
    public GameObject cooldownObject;
    float currentCooldownTime;

	// Use this for initialization
	void Start () {
        MineSpawner = GameObject.Find("MineSpawner");
        CooldownImage.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Jump") && currentCooldownTime <= 0)
        {
            cooldownObject.SetActive(true);
            CooldownImage.fillAmount = 1;
            Instantiate(Mine, gameObject.transform.position, gameObject.transform.rotation);
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
}
