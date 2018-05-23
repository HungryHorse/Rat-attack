using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public int isTutorial;
    public GameObject Player;
    public Transform Spawn;
    GameObject[] EnemyArray;
    public GameObject mapHolder;
    int currentIndex;
    public int numberOfLevels;
    GameObject newMap;
    public GenerateRandomLevel randLevelGen;
    public GameObject Portal;
    public GameObject TutorialPortal;
    public GameObject Tutorial;

    void Start()
    {
        isTutorial = PlayerPrefs.GetInt("Tutorial");
        currentIndex = 0;
        if (isTutorial == 1)
        {
            LoadTutorial();
        }
        else
        {
            UpdateMap();
        }
    }

    // Update is called once per frame
    void Update () {        
        // if the player dies destory the current map so it doesn't create any slow down
        if (Player == null)
        {
            Destroy(newMap);
        }

        // used to check if an enemy is the last one, if it is it is told whether it is in the tutorial or not so as to spawn the correct portal
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        try
        {
            if (EnemyArray.Length == 1)
            {
                EnemyArray[0].GetComponent<Enemy>().YouArelastEnemy(isTutorial);
            }
        }
        catch
        {

        }
    }

    public void LoadTutorial()
    {
        Instantiate(Tutorial, new Vector3(-0.5f, -0.5f, 0), Quaternion.identity);
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        AstarPath.active.Scan();
    }

    public void UpdateMap()
    {
        if (currentIndex != 0)
        {
            // destorys the previous level as well as the fragments still on the floorfrom killing enemies
            GameObject[] knowledge = GameObject.FindGameObjectsWithTag("Knowledge");
            foreach(GameObject element in knowledge)
            {
                Destroy(element);
            }
            Destroy(newMap);
        }
        // if you have gone through the last portal it makes the game over screen a win screen instead and ends the game
        if (currentIndex == numberOfLevels)
        {
            Player.GetComponent<PlayerStats>().won = true;
            Player.GetComponent<PlayerStats>().health = 0;
        }

        // creates a new game object to hold the next level create by the random level generator 
        newMap = Instantiate(mapHolder, new Vector3(0,0,0), Quaternion.identity);

        // calls for a random level to be created
        randLevelGen.GenNewLevel(currentIndex, newMap);

        // rescans the new level for the pathfinding
        AstarPath.active.Scan();

        // sets the player back to the spawn of the level and at the correct rotation
        Player.transform.position = Spawn.position;
        Player.transform.rotation = Quaternion.identity;

        // makes an array containing all the enemies on the new level
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");

         // incriments level up one
        currentIndex++;
    }
}
