using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour {
    public GameObject MineDeath;
    public float damage;
    public float maxRadius;

    // script on mines used to detect when an enemy steps on one and will spawn the MineDeath object which as a rappidly expanding circle collider on it to do damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            SteppedOn();
            Destroy(gameObject);
        }
    }
    
    void SteppedOn()
    {
        GameObject newMineDeath = Instantiate(MineDeath, gameObject.transform.position, gameObject.transform.rotation);
        newMineDeath.GetComponent<OnMineDeath>().damage = damage;
        newMineDeath.GetComponent<OnMineDeath>().maxRadius = maxRadius;
    }
    
}
