using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShoot : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            Shooting[] guns = collision.gameObject.GetComponentsInChildren<Shooting>();

            foreach(Shooting gun in guns)
            {
                gun.canShoot = true;
            }
        }
    }
}
