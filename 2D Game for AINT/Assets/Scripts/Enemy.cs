using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public float stunRemaining;
    public bool isTutorial;
    public bool isLast;
    public bool sawPlayer;
    public float health;
    public GameObject player;
    PlayerStats playerStats;
    public GameObject playerDirectionMonitor;
    public float adjustmentAngle = 0.0f;
    public GameObject EnemyList;
    public GameObject KnowledgeFragment;
    public GameObject Portal;
    public GameObject TutorialPortal;
    public MapManager mapManager;
    public GameObject audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioController");
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
            audioManager.GetComponent<AudioController>().PlayGettingHitSound(); 
            playerStats.health -= 10f * playerStats.resistance;
            playerStats.hit = true;
        }

        if (health <= 0)
        {
            audioManager.GetComponent<AudioController>().PlayEnemyDeathSound();
            if (isLast && isTutorial)
            {
                GameObject newPortal = Instantiate(TutorialPortal, transform.position, Quaternion.identity);
                mapManager.TutorialPortal = newPortal;
            }

            if (isLast && !isTutorial)
            {
                GameObject newPortal = Instantiate(Portal, transform.position, Quaternion.identity);
                mapManager.Portal = newPortal;
            }

            if(!isLast)
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


    public void YouArelastEnemy(int istutorial)
    {
        isLast = true;
        if(istutorial == 1)
        {
            isTutorial = true;
        }
        else
        {
            isTutorial = false;
        }
    }
}
    
