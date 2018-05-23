using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource BackgroundMusic;
    public AudioSource ShotSound;
    public AudioSource DashSound;
    public AudioSource EnemyDeathSound;
    public AudioSource ExplosionSound;
    public AudioSource GettingHitSound;
    public AudioSource MinePooperSound;
    public AudioSource PickUpSound;
    public AudioSource PlayerDeathSound;
    public AudioSource SelectSound;
    public AudioSource ShieldDecaySound;
    public AudioSource ShieldApplySound;
    public AudioSource StunSound;
    public bool FadedIn = false;
    public bool stopFadeIn;

	// this script is used by objects so that they can play sounds all from the same script, this means that the sound objects not needed to be spawned only called

	void Start () {
        BackgroundMusic.volume = 0.1f;
	}

    private void FixedUpdate()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        if(BackgroundMusic.volume != 1 && !FadedIn && !stopFadeIn)
        {
            BackgroundMusic.volume += Time.deltaTime;
        }
        if(BackgroundMusic.volume >= 1)
        {
            FadedIn = true;
        }
    }

    public void PlayShotSound()
    {
        ShotSound.Play();
    }

    public void PlayDashSound()
    {
        DashSound.Play();
    }

    public void PlayEnemyDeathSound()
    {
        EnemyDeathSound.Play();
    }

    public void PlayExplosionSound()
    {
        ExplosionSound.Play();
    }

    public void PlayGettingHitSound()
    {
        GettingHitSound.Play();
    }

    public void PlayMinePooperSound()
    {
        MinePooperSound.Play();
    }

    public void PlayPickUpSound()
    {
        PickUpSound.Play();
    }
    public void PlayPlayerDeathSound()
    {
        PlayerDeathSound.Play();
    }

    public void PlaySelectSound()
    {
        SelectSound.Play();
    }

    public void PlayShieldDecaySound()
    {
        ShieldDecaySound.Play();
    }

    public void PlayShieldApplySound()
    {
        ShieldApplySound.Play();
    }

    public void PlayStunSound()
    {
        StunSound.Play();
    }

}
