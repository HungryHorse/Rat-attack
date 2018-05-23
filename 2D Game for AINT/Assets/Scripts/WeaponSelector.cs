using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

    public Image currImageLeft;
    public Image currImageRight;
    public Text RightText;
    public Text LeftText;
    public Sprite[] WeaponImages;
    public string[] Names;
    public int currentIndexLeft;
    public int currentIndexRight;

    // on start the playerprefs are set to the left index and the right index
    void Start()
    {
        PlayerPrefs.SetInt("Fire1", currentIndexLeft);
        PlayerPrefs.SetInt("Fire2", currentIndexRight);
    }

    // Update is called once per frame
    void Update () { // in update the picture and text is told to match the index
        currImageRight.sprite = WeaponImages[currentIndexRight];
        currImageLeft.sprite = WeaponImages[currentIndexLeft];
        RightText.text = Names[currentIndexRight];
        LeftText.text = Names[currentIndexLeft];
    }

    // Moves the weapon selector on the right up one, used on the up arrow
    public void TickUpRight()
    {
        currentIndexRight++;
        if (currentIndexRight >= WeaponImages.Length)
        {
            currentIndexRight = 0;
        }
        PlayerPrefs.SetInt("Fire2", currentIndexRight);
    }

    // Moves the weapon selector on the right down one, used on the down arrow
    public void TickDownRight()
    {
        currentIndexRight--;
        if (currentIndexRight < 0)
        {
            currentIndexRight = (WeaponImages.Length-1);
        }
        PlayerPrefs.SetInt("Fire2", currentIndexRight);
    }

    // Moves the weapon selector on the left up one, used on the up arrow
    public void TickUpLeft()
    {
        currentIndexLeft++;
        if (currentIndexLeft >= WeaponImages.Length)
        {
            currentIndexLeft = 0;
        }
        PlayerPrefs.SetInt("Fire1", currentIndexLeft);
    }

    // Moves the weapon selector on the left down one, used on the down arrow
    public void TickDownLeft()
    {
        currentIndexLeft--;
        if (currentIndexLeft < 0)
        {
            currentIndexLeft = (WeaponImages.Length-1);
        }
        PlayerPrefs.SetInt("Fire1", currentIndexLeft);
    }
}
