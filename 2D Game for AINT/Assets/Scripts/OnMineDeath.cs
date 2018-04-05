using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMineDeath : MonoBehaviour {

    CircleCollider2D thisCollider;
    GameObject targetHit;
    public int rateOfIncrease;

    void Awake()
    {
        thisCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        thisCollider.radius += (rateOfIncrease * 0.01f);

        if (thisCollider.radius >= 1.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetHit = collision.gameObject;
        if (targetHit.tag == "Enemy")
        {
            targetHit.GetComponent<Enemy>().health -= 50;
        }
    }
}
