﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeFragmentScript : MonoBehaviour {

    GameObject targetHit;
    GameObject audioManager;

    private void Awake()
    {
        audioManager = GameObject.Find("AudioController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetHit = collision.gameObject;
        if (targetHit.tag == "Player")
        {
            audioManager.GetComponent<AudioController>().PlayPickUpSound();
            targetHit.GetComponent<PlayerStats>().Knowledge += 1;
            Destroy(gameObject);
        }
    }
}
