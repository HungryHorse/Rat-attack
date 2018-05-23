﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    MapManager mapManager;

    // takes the player to the next level
    void Start()
    {
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mapManager.UpdateMap();
            Destroy(gameObject);
        }
    }
}
