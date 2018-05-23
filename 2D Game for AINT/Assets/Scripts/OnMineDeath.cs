using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMineDeath : MonoBehaviour {

    CircleCollider2D thisCollider;
    GameObject targetHit;
    public int rateOfIncrease;
    public float damage;
    public float maxRadius;
    public GameObject audioManager;

    // This script creates a collider to do damage when the mine explodes
    void Awake()
    {
        audioManager = GameObject.Find("AudioController");
        audioManager.GetComponent<AudioController>().PlayExplosionSound();
        thisCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        thisCollider.radius += (rateOfIncrease * 0.01f);

        if (thisCollider.radius >= maxRadius)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetHit = collision.gameObject;
        if (targetHit.tag == "Enemy")
        {
            targetHit.GetComponent<Enemy>().health -= damage;
        }
    }
}
