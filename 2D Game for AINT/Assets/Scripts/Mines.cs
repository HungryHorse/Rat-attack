﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour {
    public GameObject MineDeath;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    

    void OnDestroy()
    {
        Instantiate(MineDeath, gameObject.transform.position, gameObject.transform.rotation);
    }
}