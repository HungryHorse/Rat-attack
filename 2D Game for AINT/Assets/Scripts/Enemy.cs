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
    Animator myAnim;

    void Start()
    {
        audioManager = GameObject.Find("AudioController");
        myAnim = transform.GetChild(0).GetComponent<Animator>();
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
            // so that the enemy itself doesn't have to rotate it contains an object that can rotate and will always face the player
            Vector3 target = player.transform.position;
            Vector3 difference = target - transform.position;

            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
            playerDirectionMonitor.transform.rotation = newRotation;

            // sends a ray from the direction that the monitor is facing which will always be towards the player to check if the player can be seen
            sendRay(playerDirectionMonitor);
        }
        else
        {
            // if the enemy has seen the player then it will always be moving so its walk animation can be set to true
            myAnim.SetBool("isWalking", true);
        }

        // This is used to do damage to the player based on distance and whether the player has the shield on or if the player has been hit too recently
        if (distanceToPlayer < 1 && playerStats.iFramesLeft <= 0 && !playerStats.shieldIsOn)
        {
            audioManager.GetComponent<AudioController>().PlayGettingHitSound(); 
            playerStats.health -= 10f * playerStats.resistance;
            playerStats.hit = true;
        }

        // used to kill enemies and destory their object, if the enemy has been told it is the last one then it will also spawn a portal on death
        // if it is not the last one then it will spawn a knowledge fragment on death instead (the currency)
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

        // used when it has been hit by the stun bomb to tell it to stop moving
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

    // checks whether the ray being sent can hit the player
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

    // used by map manager to tell an enemy it is the last and what portal it should spawn on death
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
    
