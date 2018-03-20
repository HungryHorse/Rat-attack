using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePooper : MonoBehaviour {

    public GameObject MineSpawner;
    public GameObject Mine;

	// Use this for initialization
	void Start () {
        MineSpawner = GameObject.Find("MineSpawner");
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(Mine, gameObject.transform.position, gameObject.transform.rotation);
        }
	}
}
