using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBind : MonoBehaviour {
    public GameObject Buttons;

	// Use this for initialization
	void Start () {
        Buttons = GameObject.Find("Buttons");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.SetActive(Buttons.activeInHierarchy);
	}
}
