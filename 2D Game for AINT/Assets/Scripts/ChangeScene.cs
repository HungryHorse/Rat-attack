using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
    public GameObject WarningMessage;
    public GameObject AudioManager;
    AudioSource audio;
    public AudioController audioControl;
    int sceneTochangeTo;
    bool fadeOut = false;

    private void Start()
    {
        AudioManager = GameObject.Find("BackgroundMusic");
        audio = AudioManager.GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("ActiveUpgrade"))
        {
            PlayerPrefs.SetInt("ActiveUpgrade", 0);
        }
    }

    public void OnButton(int scene)
    {
        Time.timeScale = 1;
        fadeOut = true;
        sceneTochangeTo = scene;
    }

    public void SetTutorial(int tutorial)
    {
        fadeOut = true;
        PlayerPrefs.SetInt("Tutorial", tutorial);
    }

    public void SceneChange()
    {
        if (sceneTochangeTo == 1 && PlayerPrefs.GetInt("ActiveUpgrade") == 0)
        {
            WarningMessage.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(sceneTochangeTo);
        }
    }

    public void NoUps(int yesNo)
    {
        if(yesNo == 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    void FixedUpdate()
    {
        if(fadeOut == true)
        {
            audioControl.stopFadeIn = true;
            audio.volume -= 1;
        }
        if(audio.volume <= 0)
        {
            SceneChange();
        }
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            Cursor.visible = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
