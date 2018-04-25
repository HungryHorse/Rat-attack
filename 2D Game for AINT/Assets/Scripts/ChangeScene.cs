using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
    public GameObject WarningMessage;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("ActiveUpgrade"))
        {
            PlayerPrefs.SetInt("ActiveUpgrade", 0);
        }
    }

    public void OnButton(int scene)
    {
        if (scene == 1 && PlayerPrefs.GetInt("ActiveUpgrade") == 0)
        {
            WarningMessage.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void SetTutorial(int tutorial)
    {
        PlayerPrefs.SetInt("Tutorial", tutorial);
    }

    public void NoUps(int yesNo)
    {
        if(yesNo == 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            WarningMessage.SetActive(false);
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
