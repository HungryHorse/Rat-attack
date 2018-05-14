using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliders : MonoBehaviour {

    public Slider Master;
    public Slider Music;
    public Slider SFX;


    public void OnSliderChange(Slider[] inputSliders)
    {
        inputSliders[0].value = 
        inputSliders[1].value = 
        inputSliders[2].value = 
    }
}
