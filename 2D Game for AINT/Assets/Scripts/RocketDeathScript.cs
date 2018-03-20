using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDeathScript : MonoBehaviour {

    CircleCollider2D thisCollider;
    public int rateOfIncrease;

    void Awake()
    {
        thisCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        thisCollider.radius += (rateOfIncrease * 0.01f);

        if(thisCollider.radius >= 1.5)
        {
            Destroy(gameObject);
        }
    }
}
