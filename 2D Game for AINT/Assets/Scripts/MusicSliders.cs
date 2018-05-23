using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicSliders : MonoBehaviour {
    
    public AudioMixer masterMixer;

    // Allows the UI audio sliders to change the audio mixer

    public void OnMasterSliderChange(float changeTo)
    {
         masterMixer.SetFloat("Master", changeTo);
    }
    public void OnMusicSliderChange(float changeTo)
    {
        masterMixer.SetFloat("Music", changeTo);
    }
    public void OnSFXSliderChange(float changeTo)
    {
        masterMixer.SetFloat("SoundFX", changeTo);
    }
}
