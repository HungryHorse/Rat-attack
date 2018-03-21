using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //Might not be multiple but might as well make it so it could be
    public int amount;
    public float timeBetween;
    float timeCounter;
    public GameObject EnemyPrefab;
    // Maybe add public type as a way to spawn idfferent types TODO

    private void Start()
    {
        timeCounter = 0;
    }

    private void Update()
    {
        if(timeCounter <= 0 && amount > 0)
        {
            Instantiate(EnemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
            timeCounter = timeBetween;
            amount--;
        }
        else
        {
            timeCounter -=  Time.deltaTime;
        }
    }

}
