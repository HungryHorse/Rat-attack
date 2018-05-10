using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextFromUpgrade : MonoBehaviour
{
    public Text text;
    public string PlayerPrefName;
    public string maxAmount;

	void Start ()
    {
        UpdateText();

    }
	

	public void UpdateText ()
    {
        text.text = PlayerPrefs.GetInt(PlayerPrefName).ToString() + "/" + maxAmount;
	}
}
