using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource BackgroundMusic;
    public bool FadedIn = false;

	// Use this for initialization
	void Start () {
        BackgroundMusic.volume = 0;
	}

    private void FixedUpdate()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        if(BackgroundMusic.volume != 1 && !FadedIn)
        {
            BackgroundMusic.volume += Time.deltaTime;
        }
        if(BackgroundMusic.volume >= 1)
        {
            FadedIn = true;
        }
    }
}
