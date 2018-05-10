using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour {
    public GameObject MineDeath;
    public float damage;
    public float maxRadius;

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
