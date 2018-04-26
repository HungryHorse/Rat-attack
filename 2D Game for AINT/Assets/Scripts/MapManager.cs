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
        if (Player == null)
        {
            Destroy(newMap);
        }

        try
        {
            if (EnemyArray[1] == null && EnemyArray[0] != null)
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
        Instantiate(Tutorial, new Vector3(0, 0, 0), Quaternion.identity);
        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        AstarPath.active.Scan();
    }

    public void UpdateMap()
    {
        if (currentIndex != 0)
        {
            GameObject[] knowledge = GameObject.FindGameObjectsWithTag("Knowledge");
            foreach(GameObject element in knowledge)
            {
                Destroy(element);
            }
            Destroy(newMap);
        }
        if (currentIndex == numberOfLevels)
        {
            Player.GetComponent<PlayerStats>().won = true;
            Player.GetComponent<PlayerStats>().health = 0;
        }

        newMap = Instantiate(mapHolder, new Vector3(0,0,0), Quaternion.identity);

        randLevelGen.GenNewLevel(currentIndex, newMap);

        AstarPath.active.Scan();

        Player.transform.position = Spawn.position;
        Player.transform.rotation = Quaternion.identity;

        EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        currentIndex++;
    }
}
