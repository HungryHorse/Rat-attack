using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool sawPlayer;
    public int health;
    public GameObject player;
    PlayerStats playerStats;
    public GameObject playerDirectionMonitor;
    public float adjustmentAngle = 0.0f;

    void Start()
    {
        player = GameObject.Find("Player");
        playerDirectionMonitor = GameObject.Find("PlayerDirectionMonitor");
        playerStats = player.GetComponent<PlayerStats>(); 
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (sawPlayer)
        {
            Vector3 target = player.transform.position;
            Vector3 difference = target - transform.position;

            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
            transform.rotation = Quaternion.Lerp(gameObject.transform.rotation ,newRotation, Time.deltaTime * 5.0f);
        }
        else
        {
            Vector3 target = player.transform.position;
            Vector3 difference = target - transform.position;

            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
            playerDirectionMonitor.transform.rotation = newRotation;

            sendRay(playerDirectionMonitor);
        }


        if (distanceToPlayer < 1 && playerStats.iFramesLeft <= 0)
        {
            playerStats.health -= 10;
            playerStats.hit = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void sendRay(GameObject origin)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.transform.position, origin.transform.up);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player" && Vector3.Distance(player.transform.position, gameObject.transform.position) < 15)
            {
                sawPlayer = true;
            }
        }
    }
}
    
