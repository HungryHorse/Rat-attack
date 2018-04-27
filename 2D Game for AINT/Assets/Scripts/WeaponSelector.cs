using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

    public Image currImageLeft;
    public Image currImageRight;
    public Sprite[] WeaponImages;
    public int currentIndexLeft;
    public int currentIndexRight;

    void Start()
    {
        PlayerPrefs.SetInt("Fire1", currentIndexLeft);
        PlayerPrefs.SetInt("Fire2", currentIndexRight);
    }

    // Update is called once per frame
    void Update () {
        currImageRight.sprite = WeaponImages[currentIndexRight];
        currImageLeft.sprite = WeaponImages[currentIndexLeft];
    }

    public void TickUpRight()
    {
        currentIndexRight++;
        if (currentIndexRight >= WeaponImages.Length)
        {
            currentIndexRight = 0;
        }
        PlayerPrefs.SetInt("Fire2", currentIndexRight);
    }

    public void TickDownRight()
    {
        currentIndexRight--;
        if (currentIndexRight < 0)
        {
            currentIndexRight = (WeaponImages.Length-1);
        }
        PlayerPrefs.SetInt("Fire2", currentIndexRight);
    }

    public void TickUpLeft()
    {
        currentIndexLeft++;
        if (currentIndexLeft >= WeaponImages.Length)
        {
            currentIndexLeft = 0;
        }
        PlayerPrefs.SetInt("Fire1", currentIndexLeft);
    }

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
