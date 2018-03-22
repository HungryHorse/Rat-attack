using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int health;
    public float Knowledge;
    public bool hit;
    public float iFrames;
    public float iFramesLeft;

    private void Start()
    {
        iFramesLeft = 0;
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
            Destroy(gameObject);
        }
    }
}
