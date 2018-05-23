using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPortal : MonoBehaviour {
    ChangeScene Scene;

    void Start()
    {
        Scene = GameObject.Find("SceneChanger").GetComponent<ChangeScene>();
    }
    // ends the tutorial
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Scene.OnButton(0);
        }
    }
}
