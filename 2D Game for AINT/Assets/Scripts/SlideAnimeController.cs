using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SlideAnimeController : MonoBehaviour {

    public Animator anim;
    public Animator anim2;

    public void GoRight()
    {
        anim.SetBool("Move", true);
        anim2.SetBool("Move", true);
    }

    public void GoLeft()
    {
        anim.SetBool("Move", false);
        anim2.SetBool("Move", false);
    }
}
