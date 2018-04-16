using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChosenUpgrade : MonoBehaviour {

	public void SetRightEye()
    {
        PlayerPrefs.SetInt("ActiveUpgrade", 1);
    }
    public void SetLeftEye()
    {
        PlayerPrefs.SetInt("ActiveUpgrade", 2);
    }
    public void SetRightLeg()
    {
        PlayerPrefs.SetInt("ActiveUpgrade", 3);
    }
    public void SetLeftLeg()
    {
        PlayerPrefs.SetInt("ActiveUpgrade", 4);
    }

}
