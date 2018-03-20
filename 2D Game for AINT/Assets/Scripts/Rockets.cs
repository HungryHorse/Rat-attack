using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour {
    public GameObject RocketDeath;

    void OnDestroy()
    {
        Debug.Log("Destroyed Rocket");
        Instantiate(RocketDeath, gameObject.transform.position, gameObject.transform.rotation);
    }
}
