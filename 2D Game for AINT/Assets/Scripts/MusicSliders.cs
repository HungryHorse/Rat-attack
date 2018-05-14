using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicSliders : MonoBehaviour {

    public Slider Master;
    public Slider Music;
    public Slider SFX;
    public AudioMixer masterMixer;


    public void OnSliderChange(Slider[] inputSliders)
    {
        inputSliders[0].value = 
        inputSliders[1].value = 
        inputSliders[2].value = 
    }
}
