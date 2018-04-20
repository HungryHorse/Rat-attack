using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public float stunRemaining;
    public bool sawPlayer;
    public int health;
    public GameObject player;
    PlayerStats playerStats;
    public GameObject playerDirectionMonitor;
    public float adjustmentAngle = 0.0f;
    public GameObject EnemyList;
    public GameObject KnowledgeFragment;
    public GameObject Portal;
    public MapManager mapManager;

    void Start()
    {
        player = GameObject.Find("Player");
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        playerDirectionMonitor = gameObject.transform.GetChild(1).gameObject;
        playerStats = player.GetComponent<PlayerStats>();
        EnemyList = gameObject.transform.parent.gameObject;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if(!sawPlayer)
        {
            Vector3 target = player.transform.position;
            Vector3 difference = target - transform.position;

            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
            playerDirectionMonitor.transform.rotation = newRotation;

            sendRay(playerDirectionMonitor);
        }


        if (distanceToPlayer < 1 && playerStats.iFramesLeft <= 0 && !playerStats.shieldIsOn)
        {
            playerStats.health -= 10;
            playerStats.hit = true;
        }

        if (health <= 0)
        {
            if(EnemyList.transform.childCount == 1)
            {
                GameObject newPortal = Instantiate(Portal, transform.position, Quaternion.identity);
                mapManager.Portal = newPortal;
            }
            else
            {
                Instantiate(KnowledgeFragment, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        if (stunRemaining >= 0)
        {
            stunRemaining -= Time.deltaTime;
            gameObject.GetComponent<AIPath>().canMove = false;
        }
        else
        {
            gameObject.GetComponent<AIPath>().canMove = true;
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
    
