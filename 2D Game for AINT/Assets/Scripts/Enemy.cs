using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool sawPlayer;
    public GameObject player;
    public float adjustmentAngle = 0.0f;

    void Start()
    {
        player = GameObject.Find("Player");

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
    }

    void Update()
    {
        Vector3 target = player.transform.position;
        Vector3 difference = target - transform.position;

        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
        transform.rotation = newRotation;
        
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.up);

        if (hit.collider != null)
        {
            if(hit.collider.tag == "Player")
            {
                sawPlayer = true;
            }
        }
    }
}
    
