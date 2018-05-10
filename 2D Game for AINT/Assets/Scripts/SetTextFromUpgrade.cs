using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextFromUpgrade : MonoBehaviour
{
    public Text text;

	void Start ()
    {
        UpdateText();

    }
	

	public void UpdateText ()
    {
        text.text = PlayerPrefs.GetInt("CooldownUpgrade").ToString() + "/5";
	}
}
